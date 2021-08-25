<template>
  <div
    class="field-input-container input-date-container"
    :class="{
      'input-border-red': !(selfRequiredValid && selfValid) && !focusing,
    }"
    :id="id"
    :title="tooltip"
  >
    <v-date-picker
      v-model="pickedValue"
      :masks="masks"
      :max-date="maxDate"
      :min-date="minDate"
    >
      <template v-slot="{ inputValue, inputEvents }">
        <div class="input-date">
          <input
            ref="input"
            :value="inputValue"
            v-bind="$attrs"
            v-on="inputEvents"
            @blur="onInputBlured"
          />
          <div
            class="sprite icon-calendar"
            @click.stop="$refs.input.focus()"
          ></div>
        </div>
      </template>
    </v-date-picker>
  </div>
</template>

<script>
import { DatePicker as VDatePicker } from "v-calendar";
import Formatter from "../../../common/format";
import ValidatorMixin from "../../../common/validate";
import BaseInput from "./Index.vue";
import { INPUT_WARNING } from "../../../resources/const";

/**
 * Component Input ngày tháng năm
 * Created_by: VMHOANG
 */
export default {
  extends: BaseInput,

  emits: ["update:modelValue"],

  components: { VDatePicker },

  mixins: [ValidatorMixin],

  props: {
    //v-model
    modelValue: {
      type: String,
    },
    dateFormat: {
      type: String,
      default: "DD/MM/YYYY",
    },
    class: {
      type: String,
    },
    id: {
      type: String,
    },
  },

  data() {
    return {
      pickedValue: null,

      inputValue: "",

      modelValueInDate: null,

      masks: {
        input: this.dateFormat,
      },

      //Ngày tối đa
      maxDate: new Date(),
      //Ngày tối thiểu
      minDate: new Date("1900-01-01"),
    };
  },

  watch: {
    /**
     * Hàm theo dõi props.value - gán lại inputValue khi props thay đổi
     * CREATED_BY: VMHOANG (21/08/2021)
     */
    modelValue(newValue, oldValue) {
      if (newValue !== oldValue) {
        let date = new Date(newValue);

        if (this.testInputDateFormat(newValue)) {
          this.modelValueInDate = date;
          this.pickedValue = date;
        } else if (newValue === "") {
          this.modelValueInDate = null;
          this.pickedValue = null;
        } else {
          this.$emit("update:modelValue", "");
        }
        this.selfValid = true;
      }
    },

    /**
     * Hàm theo dõi value được chọn bởi v-calendar
     * CREATED_BY: VMHOANG (21/08/2021)
     */
    pickedValue(newValue) {
      if (newValue !== this.modelValueInDate && newValue) {
        this.$emit(
          "update:modelValue",
          Formatter.formatDateForInput(this.pickedValue)
        );
      } else if (newValue !== this.modelValueInDate) {
        this.$emit("update:modelValue", "");
      }
      this.selfValid = true;
    },
  },

  methods: {
    /**
     * Overwrite lại hàm validateInput
     * CREATED_BY: VMHOANG (21/08/2021)
     */

    validateInput() {
      this.selfValid = true;

      if (!this.required && !this.inputValue) {
        this.selfRequiredValid = true;
        return;
      }

      if (!this.inputValue && this.required) {
        this.selfRequiredValid = false;
        this.tooltip = INPUT_WARNING.CANT_BE_NULL.format(this.displayName);
      } else {
        this.selfRequiredValid = true;
      }
    },
  },
};
</script>

<style lang="scss">
.input-date-container {
  .input-date {
    width: 100%;
    min-width: 0px;
    position: relative;
    height: 100%;
    display: flex;
    justify-content: space-between;
    overflow: visible;
    input {
      min-width: 0px;
      width: 100%;
      flex: 1;
    }
  }
}
</style> 