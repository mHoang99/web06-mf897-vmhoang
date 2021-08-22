<template lang="">
    <button 
    v-bind="$attrs"
    class="m-btn"
    >
        <div v-if="icon" class="m-btn-icon" :class="icon"></div>
        <div v-if="$slots.default" class="m-btn-text"><slot/></div>
    </button>
</template>

<script>
/**
 * Base button component
 * Created_by: VMHOANG
 */
export default {
  name: "BaseButton",
  props: {
    icon: {
      type: String,
    },
  },
};
</script>

<style scoped>
@import "./Index.css";
</style>