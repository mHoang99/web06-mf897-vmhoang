<template>
  <div
    class="field-input-container m-dropdown-input"
    :id="id"
    :title="tooltip"
    :class="{
      'input-border-red':
        !(selfRequiredValid && selfValid && itemValid) && !focusing,
      dropdown: isDropdown,
    }"
  >
    <input
      ref="input"
      type="text"
      :id="id"
      :value="inputValue"
      v-bind="$attrs"
      @input="onInput"
      @blur="onInputBlured"
      @keyup="onInputKeyUp"
      autocomplete="off"
      :readonly="isDropdown"
    />
    <div class="m-dropdown-open" @click="toggleDropdown">
      <div
        :class="{ 'icon-rotate-up': true, 'icon-rotate-down': open }"
        class="icon-arrow-down sprite"
      ></div>
    </div>
  </div>
</template>

<script>
import { INPUT_WARNING } from '../../../const';
import BaseInput from "../input/Index.vue";

/**
 * Input của combobox
 * Created_by: VMHOANG
 */
export default {
  extends: BaseInput,

  emits: [
    "toggle-dropdown",
    "move-selected-down",
    "move-selected-down",
    "enter",
    "self-valid-changed",
    "self-required-valid-changed",
  ],

  props: {
    //Mở
    open: {
      type: Boolean,
    },
    //Giá trị của item
    itemValue: {
      type: String,
    },
    //Item được chọn hợp lệ
    itemValid: {
      type: Boolean,
    },
    //Là dropdown
    isDropdown: {
      type: Boolean,
      default: false,
    },


  },

  watch: {
    /**
     * Theo dõi input value
     * CREATED_BY: VMHOANG (18/07/2021)
     */
    inputValue() {
      //overwrite bằng hàm rỗng
    },
    /**
     * Theo dõi itemValue thay đổi
     * CREATED_BY: VMHOANG (18/07/2021)
     */
    itemValue() {
      this.outputValue = this.itemValue;
    },
    /**
     * Theo dõi selfValid thay đổi
     * CREATED_BY: VMHOANG (19/07/2021)
     */
    selfValid(newValue) {
      this.$emit("self-valid-changed", newValue);
    },
    /**
     * Theo dõi selfRequiredValid thay đổi
     * CREATED_BY: VMHOANG (19/07/2021)
     */
    selfRequiredValid(newValue) {
      this.$emit("self-required-valid-changed", newValue);
    },
  },

  methods: {
    /**
     * đóng mở dropdown
     * CREATED_BY: VMHOANG (14/07/2021)
     */
    toggleDropdown (event) {
      if (!this.open) {
        this.$refs.input.focus();
      }
      this.$emit("toggle-dropdown", event);
    },

    /**
     * ấn clear
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    onClearClicked () {
      this.$emit("clear");
    },

    /**
     * handle input khi blur
     * CREATED_BY: VMHOANG (17/07/2021)
     */
    onInputBlured (event) {
      this.focusing = false;

      this.validateInput();
      this.$emit("blur", event);
    },

    customValidateInput() {
      //Kiểm tra trường không được rỗng
      if (!this.itemValue && this.required) {
        this.selfRequiredValid = false;
        this.tooltip = INPUT_WARNING.CANT_BE_NULL.format(this.displayName);
      } else {
        this.selfRequiredValid = true;
      }
    },

    /**
     * Hàm reset giá trị
     * CREATED_BY: VMHOANG (20/08/2021)
     */
    reset () {
      this.selfValid = true;
      this.selfRequiredValid = true;
      this.focusing = false;
      this.tooltip = "";
    },
  },
};
</script>

<style scoped>
@import "./ComboBoxInput.css";
</style>