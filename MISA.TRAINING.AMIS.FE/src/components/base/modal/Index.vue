<template lang="">
    <div v-if="open" class="m-modal">
    <div class="m-modal-backdrop">
      <div class="m-modal-card">
        <div class="loader-container">
          <div class="loader"></div>
        </div>
        <div class="m-modal-header">
            <slot name='header'></slot>
        </div>
        <div class="m-modal-content">
            <slot name='content'></slot>
        </div>
        <div class="m-modal-footer">
            <slot name='footer'></slot>
        </div>

        <the-loading :show="loading"></the-loading>
      </div>
    </div>
  </div>
</template>

<script>
/*
 * Component modal hiển thi
 * Created_by: VMHOANG
 */
export default {
  name: "TheModal",
  props: {
    open: {
      type: Boolean,
      default: false,
    },
    loading: {
      type: Boolean,
      default: false,
    },
  },

  methods: {
  },
};
</script>

<style scoped>
@import "./Index.css";
</style>