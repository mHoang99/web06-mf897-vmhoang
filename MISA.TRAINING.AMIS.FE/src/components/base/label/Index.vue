<template>
  <div class="label-field-input">
    <label>
      {{ label }}
      <span v-if="required" style="color: red"> * </span>
    </label>
    <slot></slot>
  </div>
</template>

<script>
/*
 * Component đánh nhãn
 * Created_by: VMHOANG
 */
export default {
  name: "TheLabel",
  components: {},
  props: {
    label: {
      type: String,
    },
    required: {
      type: Boolean,
    },
  },
};
</script>

<style scoped>
@import "./Index.css";
</style>