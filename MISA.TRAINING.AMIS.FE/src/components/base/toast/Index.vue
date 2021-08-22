<template>
  <div class="m-toast" ref="toast">
    <div class="m-toast-icon" :class="styleClass.color">
      <em :class="styleClass.icon"></em>
    </div>
    <div class="m-toast-content">
      <slot></slot>
    </div>
    <div class="m-toast-close" :class="styleClass.color" @click="onClose">
      <em class="fas fa-times"></em>
    </div>
  </div>
</template>
<script>
export default {
  /*
   * Component toast thông báo
   * Created_by: VMHOANG
   */
  name: "TheToast",
  props: {
    //warning - alert - info - success
    toastType: {
      type: String,
      default: "info",
    },
    id: {
      type: String,
      required: true,
    },
  },

  computed: {
    /**
     * style classes cho từng loại toast
     * CREATED_BY: VMHOANG (19/07/2021)
     */
    styleClass() {
      let obj = {};
      switch (this.toastType) {
        case "alert":
          obj.icon = `fas fa-exclamation-triangle`;
          obj.color = `color-alert`;
          break;
        case "warning":
          obj.icon = `fas fa-exclamation-circle`;
          obj.color = `color-warning`;
          break;
        case "success":
          obj.icon = `fas fa-check`;
          obj.color = `color-success`;
          break;
        case "info":
          obj.icon = `fas fa-info`;
          obj.color = `color-info`;
          break;
        default:
          obj.icon = "";
          obj.color = "";
      }
      return obj;
    },
  },

  methods: {
    /**
     * Đóng toast
     * CREATED_BY: VMHOANG (19/07/2021)
     */
    onClose() {
      this.$store.commit("removeNoti", this.id);
    },
  },
};
</script>
<style scoped>
@import "./Index.css";
</style>