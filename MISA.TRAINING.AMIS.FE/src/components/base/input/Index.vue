<template>
  <div
    class="field-input-container"
    :class="{
      'icon-field-input': icon,
      'input-border-red': !(selfRequiredValid && selfValid) && !focusing,
    }"
    :id="id"
    :title="tooltip"
  >
    <input
      ref="input"
      autocomplete="off"
      v-bind="$attrs"
      :value="inputValue"
      @input="onInput"
      @change="onInputChange"
      @blur="onInputBlured"
      @keyup="onInputKeyUp"
      @focus="onInputFocus"
    />
    <div v-if="icon" class="field-icon sprite" :class="icon"></div>
  </div>
</template>

<script>
import mixins from "../../../common/utils";
import ValidatorMixin from "../../../common/validate";
import { INPUT_WARNING } from "../../../const";

/**
 * Base Input component
 * Created_by: VMHOANG
 */
export default {
  name: "BaseInput",

  inheritAttrs: false,

  mixins: [ValidatorMixin],

  emits: [
    "clear",
    "input",
    "change",
    "blur",
    "keyup",
    "focus",
    "update:modelValue",
  ],

  props: {
    icon: {
      type: String,
    },
    value: {
      type: String,
    },
    id: {
      type: String,
    },
    required: {
      type: Boolean,
      default: false,
    },
    //loại input
    fieldType: {
      type: String,
    },
    displayName: {
      type: String,
      default: "",
    },
    //v-model
    modelValue: {
      type: String,
    },
    modelModifiers: {
      default: () => ({}),
    },
  },

  data() {
    return {
      //giá trị của ô input
      inputValue: this.modelValue ? this.modelValue : this.value,
      //giá trị thật
      outputValue: "",
      //Tự kiểm tra
      selfValid: true,
      //Tự kiểm tra không rỗng
      selfRequiredValid: true,
      //Đang được focus
      focusing: false,
      //Nội dung tooltip
      tooltip: "",
    };
  },

  watch: {
    /**
     * Hàm theo dõi props.value - gán lại inputValue khi props thay đổi
     * CREATED_BY: VMHOANG (13/07/2021)
     */
    value(newValue) {
      this.inputValue = newValue;
      this.validateInput();
    },

    /**
     * Hàm theo dõi modelValue của v-model
     * CREATED_BY: VMHOANG (19/08/2021)
     */
    modelValue(newValue, oldValue) {
      if (newValue !== oldValue) {
        this.inputValue = newValue;
        this.validateInput();
      }
    },

    /**
     * Hàm theo dõi inputValue
     * CREATED_BY: VMHOANG (13/07/2021)
     */
    inputValue(newValue) {
      this.outputValue = newValue;
    },
  },
  
  methods: {
    /**
     * Handler bấm clear input
     * CREATED_BY: VMHOANG (14/07/2021)
     */
    onClearClicked () {
      this.inputValue = "";

      this.$refs.input.focus();

      this.$emit("clear");
    },

    /**
     * Handler khi input
     * CREATED_BY: VMHOANG (14/07/2021)
     */
    onInput (event) {
      this.inputValue = event.currentTarget.value;
      this.$emit("input", event);
      this.$emit("update:modelValue", this.inputValue);
    },

    /**
     * Handler khi input blur
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    onInputBlured (event) {
      this.focusing = false;

      this.validateInput();

      this.$emit("blur", event);

      this.$emit("update:modelValue", this.outputValue);
    },

    /**
     * Handler khi keyup
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    onInputKeyUp (event) {
      this.inputValue = event.target.value;
      switch (this.fieldType) {
        case "number":
          this.inputValue = mixins.extractNumberFromString(this.inputValue);
          break;
        default:
          break;
      }
      this.$emit("keyup", event);
    },

    /**
     * Handler khi input thay đổi
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    onInputChange (event) {
      this.inputValue = event.target.value;
      this.$emit("change", event);
    },

    /**
     * Handler khi input thay fucus
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    onInputFocus (event) {
      this.focusing = true;
      this.$emit("focus", event);
    },

    /**
     * Hàm validate input
     * CREATED_BY: VMHOANG (18/07/2021)
     */
    validateInput () {
      //Rỗng và không bắt buộc
      if (!this.required && !this.inputValue) {
        this.selfValid = true;
        this.selfRequiredValid = true;
        return;
      }

      //Rỗng và bắt buộc
      if (!this.inputValue && this.required) {
        this.selfRequiredValid = false;
        this.tooltip = INPUT_WARNING.CANT_BE_NULL.format(this.displayName);
        return;
      } else {
        this.selfRequiredValid = true;
      }

      //validate dựa trên fieldtype
      switch (this.fieldType) {
        //email
        case "email":
          this.selfValid = this.testEmail(this.inputValue);
          this.tooltip = this.selfValid ? "" : INPUT_WARNING.INVALID_EMAIL;
          break;
        //tên
        case "name":
          this.selfValid = this.testName(this.inputValue);
          this.tooltip = this.selfValid ? "" : INPUT_WARNING.INVALID_NAME;
          break;
        //số
        case "number":
          this.selfValid =
            this.testNumberOnly(this.inputValue) || !this.inputValue;
          this.tooltip = this.selfValid
            ? ""
            : INPUT_WARNING.INVALID_NUMBER.format(this.displayName);
          break;
        //điện thoại
        case "phone":
          this.selfValid =
            this.testPhoneNumber(this.inputValue) || !this.inputValue;
          this.tooltip = this.selfValid
            ? ""
            : INPUT_WARNING.INVALID_FORMAT.format(this.displayName);
          break;
        //mặc định
        default:
          this.selfValid = true;
          break;
      }

      this.customValidateInput();

      //Tự validate đúng + bắt buộc đúng
      if (this.selfRequiredValid && this.selfValid) {
        this.tooltip = "";
      }
    },

    /**
     * Hàm validate input cho class con
     * CREATED_BY: VMHOANG (18/07/2021)
     */
    customValidateInput() {
      //TO BE OVERRIDEN
    },

    /**
     * Hàm reset giá trị
     * CREATED_BY: VMHOANG (18/07/2021)
     */
    reset () {
      this.inputValue = this.value;
      this.outputValue = this.inputValue;
      this.selfValid = true;
      this.selfRequiredValid = true;
      this.focusing = false;
      this.tooltip = "";
    },
  },
};
</script>

<style scoped>
@import "./Index.css";

.tooltip-red {
  background-color: red !important;
  color: white;
}
</style>