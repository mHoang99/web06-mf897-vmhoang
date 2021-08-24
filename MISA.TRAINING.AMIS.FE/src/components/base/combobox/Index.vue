<template>
  <div class="m-dropdown" :id="id" ref="combobox">
    <combo-box-input
      :id="id + 'Input'"
      :open="open"
      :value="inputValue"
      :itemValue="outputValue"
      :itemValid="itemValid"
      v-bind="$attrs"
      :displayName="displayName"
      ref="input"
      @self-valid-changed="onSelfValidChanged"
      @self-required-valid-changed="onSelfRequiredValidChanged"
      @input="onInputChange"
      @change="onInputChange"
      @blur="onInputBlur"
      @toggle-dropdown="toggleDropdown"
      @keydown.down="moveDown"
      @keydown.up="moveUp"
      @keydown.tab="onTabOut"
      @keydown.enter="onItemSelect(selectingItemIndex)"
    />
    <combo-box-item-container
      ref="container"
      :show="open"
      :id="id + 'Container'"
      :up="showUp"
      :dropdownItems="dropdownItems"
      :selectedIndex="selectedItemIndex"
      :selectingIndex="selectingItemIndex"
      @item-click="onItemSelect"
    />
  </div>
</template>

<script>
import ComboBoxInput from "./ComboBoxInput.vue";
import ComboBoxItemContainer from "./ComboBoxItemContainer.vue";
import Mixins from "../../../common/utils";
import { mapActions, mapGetters } from "vuex";
import { INPUT_WARNING } from "../../../const";

/**
 * Combobox component
 * Created_by: VMHOANG
 */
export default {
  name: "ComboBox",

  emits: ["item-selected", "update:modelValue"],

  components: {
    ComboBoxInput,
    ComboBoxItemContainer,
  },

  props: {
    id: {
      type: String,
    },
    //Tên của loại dữ liệu
    fieldName: {
      type: String,
    },
    //Giá trị mặc định cho item đầu tiên
    defaultValue: {
      type: String,
    },
    modelValue: {
      type: String,
    },
    displayName: {
      type: String,
    },
    modelModifiers: {
      default: () => ({}),
    },
    required: {
      type: Boolean,
    },
  },

  data() {
    return {
      //Các items hiện ra
      dropdownItems: [],
      //Tất cả các items nguyên bản
      dropdownItemsOriginal: [],
      //mở item container
      open: false,
      //item đã được chọn
      selectedItemIndex: -1,
      //item đang được chọn
      selectingItemIndex: -1,
      //Giá trị của ô input
      inputValue: "",
      //Giá trị thật trả lại
      outputValue: null,
      //Nếu item đang được chọn hợp lệ
      itemValid: true,
      //Tự kiểm tra input
      selfValid: true,
      //Tự kiểm tra không được trống
      selfRequiredValid: true,
      //Hiện dropdown lên trên
      showUp: false,
    };
  },

  watch: {
    /**
     * Lắng nghe danh sách item thay đổi
     * CREATED_BY: VMHOANG (16/08/2021)
     *  */
    dictionary: {
      immediate: true,
      handler(newValue) {
        if (newValue) {
          this.dropdownItemsOriginal = [...newValue];

          //Có item mặc định
          if (this.defaultValue) {
            let firstEle = {
              text: this.defaultValue,
              value: "",
              data: "",
            };

            this.dropdownItemsOriginal = [
              firstEle,
              ...this.dropdownItemsOriginal,
            ];
          }

          //Gán danh sách hiện tại bằng danh sách gốc
          this.dropdownItems = [...this.dropdownItemsOriginal];
        }
      },
    },

    /**
     * Theo dõi input value
     * CREATED_BY: VMHOANG (14/07/2021)
     */
    inputValue(newValue) {
      if (this.inputValue !== "" && this.inputValue !== this.defaultValue) {
        this.open = true;
      }

      //Tìm kiếm vị trí inputValue trong dropdownItem
      let positionOfText = this.findPositionOfText(newValue);

      if (positionOfText >= 0) {
        //chọn item
        this.open = false;
        this.selectedItemIndex = positionOfText;
      } else {
        //reset
        this.selectedItemIndex = -1;
        this.$emit("update:modelValue", "");
      }

      if (newValue == "") {
        //reset
        this.selectedItemIndex = -1;
        this.selectingItemIndex = -1;
        this.dropdownItems = [...this.dropdownItemsOriginal];
      } else {
        //Tìm kiếm text
        this.dropdownItems = [...this.searchForItemText(newValue)];
      }

      if (this.dropdownItems.length <= 0) {
        this.itemValid = false;
      } else {
        this.itemValid = true;
      }
    },

    /**
     * Theo dõi modelValue cho v-model
     * CREATED_BY: VMHOANG (19/08/2021)
     */
    modelValue(newValue, oldValue) {
      if (newValue !== oldValue) {
        let pos = this.findPositionOfValue(newValue);
        if (pos < 0) {
          this.onItemSelect(-1);
        } else {
          this.onItemSelect(pos);
        }
      }
    },

    /**
     * Theo dõi dropdownItems thay đổi
     * CREATED_BY: VMHOANG (14/07/2021)
     */
    dropdownItems(newValue, oldValue) {
      if (newValue != oldValue) {
        this.selectingItemIndex = this.selectedItemIndex;
      }
    },

    /**
     * Theo dõi index đang được chọn
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    selectedItemIndex(newValue) {
      if (newValue >= 0 && newValue < this.dropdownItemsOriginal.length) {
        this.outputValue = this.dropdownItemsOriginal[newValue].value;
      } else {
        this.outputValue = null;
      }
    },

    /**
     * Theo dõi đóng/mở
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    open(newValue) {
      if (newValue === true) {
        let containerMaxHeight = 200;
        // console.log(window.innerHeight - this.$refs.combobox.getBoundingClientRect().y)
        if (
          window.innerHeight - this.$refs.combobox.getBoundingClientRect().y <
          containerMaxHeight
        ) {
          this.showUp = true;
        } else {
          this.showUp = false;
        }
      }
    },
  },

  created() {
    document.removeEventListener("click", this.documentClick);
    document.addEventListener("click", this.documentClick);
  },

  computed: {
    ...mapGetters(["dropdownDictionary"]),

    dictionary() {
      return this.dropdownDictionary(this.fieldName);
    },
  },

  methods: {
    ...mapActions(["fetchDropdownData"]),

    /**
     * đóng/mở dropdown
     * CREATED_BY: VMHOANG (14/07/2021)
     */
    toggleDropdown() {
      this.open = !this.open;
    },

    /**
     * Tìm kiếm item bằng text
     * @param {String} text
     * @returns danh sách item tương ứng
     * CREATED_BY: VMHOANG (18/07/2021)
     */
    searchForItemText(text) {
      let returnDict = [];

      this.dropdownItemsOriginal.forEach((item) => {
        if (text === item.text) {
          returnDict = [...this.dropdownItemsOriginal];
          return null;
        }
        if (
          Mixins.removeVietnameseTones(item.text)
            .toUpperCase()
            .includes(Mixins.removeVietnameseTones(text).toUpperCase())
        ) {
          returnDict.push(item);
        }
      });

      return returnDict;
    },

    /**
     * Chọn item bằng value
     * @param {String} value
     * @returns danh sách item tương ứng
     * CREATED_BY: VMHOANG (18/07/2021)
     */
    selectByValue(value) {
      let position = this.findPositionOfValue(value);
      this.onItemSelect(position);
    },

    /**
     * Tìm vị trí item theo value
     * @param {String} value
     * @returns Số thứ tự của item
     * CREATED_BY: VMHOANG (18/07/2021)
     */
    findPositionOfValue(value) {
      let returnIndex = -1;
      this.dropdownItemsOriginal.forEach((item, index) => {
        if (item.value == value) {
          returnIndex = index;
          return null;
        }
      });

      return returnIndex;
    },

    /**
     * Tìm vị trí item theo text
     * @param {String} text
     * @returns Số thứ tự của item
     * CREATED_BY: VMHOANG (18/07/2021)
     */
    findPositionOfText(text) {
      let returnIndex = -1;
      this.dropdownItemsOriginal.forEach((item, index) => {
        if (item.text == text) {
          returnIndex = index;
          return null;
        }
      });

      return returnIndex;
    },

    /**
     * Handler input change
     * CREATED_BY: VMHOANG (14/07/2021)
     */
    onInputChange(event) {
      this.inputValue = event.target.value;
    },

    /**
     * Handler tab khỏi ô input
     * CREATED_BY: VMHOANG (23/07/2021)
     */
    onTabOut() {
      this.open = false;
    },

    /**
     * Handler input blur
     * CREATED_BY: VMHOANG (14/07/2021)
     */
    onInputBlur() {
      //item không hợp lệ
      if (this.selectedItemIndex <= 0) {
        this.itemValid = false;
        //báo lỗi ra tooltip
        if (this.inputValue) {
          this.$refs.input.tooltip = INPUT_WARNING.INVALID_FIELD.format(
            this.displayName
          );
          return;
        }
      }

      if (!this.outputValue && this.required) {
        this.selfRequiredValid = false;
        this.$refs.input.tooltip = INPUT_WARNING.CANT_BE_NULL.format(
          this.displayName
        );
      } else {
        this.selfRequiredValid = true;
      }
    },

    /**
     * Handler bấm mũi tên xuống
     * CREATED_BY: VMHOANG (17/07/2021)
     */
    moveDown(event) {
      event.preventDefault();
      this.open = true;
      if (this.selectingItemIndex < this.dropdownItems.length - 1) {
        this.selectingItemIndex++;
      }
    },

    /**
     * Handler bấm mũi tên lên
     * CREATED_BY: VMHOANG (17/07/2021)
     */
    moveUp(event) {
      event.preventDefault();
      if (this.selectingItemIndex > 0) {
        this.selectingItemIndex--;
      }
      if (this.selectingItemIndex < 0) {
        this.open = false;
      }
    },

    /**
     * Handler chọn vào 1 item
     * CREATED_BY: VMHOANG (14/07/2021)
     */
    onItemSelect(index) {
      if (index < 0) {
        this.selectedItemIndex = -1;
        this.selectingItemIndex = -1;
        return;
      }

      if (this.dropdownItems.length > 0) {
        let ele = this.dropdownItems[index];
        let validIndex = this.dropdownItemsOriginal.indexOf(ele);

        this.selectedItemIndex = validIndex;
        this.selectingItemIndex = this.selectedItemIndex;

        this.inputValue = this.dropdownItems[index].text;

        this.$emit("item-selected", this.dropdownItems[index]);
        this.$emit("update:modelValue", this.dropdownItems[index].value);
      }
      this.open = false;
    },

    /**
     * Handle selfValid thay đổi
     * CREATED_BY: VMHOANG (19/07/2021)
     */
    onSelfValidChanged(value) {
      this.selfValid = value;
    },

    /**
     * Handle selfRequiredValid thay đổi
     * CREATED_BY: VMHOANG (19/07/2021)
     */
    onSelfRequiredValidChanged(value) {
      this.selfRequiredValid = value;
    },

    /**
     * Handler click vào document
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    documentClick(e) {
      let el = this.$refs.combobox;
      let target = e.target;
      if (el !== target && !el.contains(target)) {
        //đóng dropdown
        this.open = false;
      }
    },

    /**
     * reset mặc định
     * CREATED_BY: VMHOANG (19/07/2021)
     */
    reset() {
      this.$refs.input.reset();
    },
  },

  unmounted() {
    //Xóa document event
    document.removeEventListener("click", this.documentClick);
  },
};
</script>

<style scoped>
@import "./Index.css";
</style>