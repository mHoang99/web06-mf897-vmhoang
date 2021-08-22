<template>
  <div
    ref="contextMenu"
    class="context-menu"
    v-if="isShow"
    :style="{
      top: status.positionY,
      left: status.positionX,
    }"
  >
    <slot></slot>
  </div>
</template>
<script>
export default {
  name: "ContextMenu",
  props: {
    status: {
      isShow: {
        type: Boolean,
      },
      positionX: {
        type: String | Number,
      },
      positionY: {
        type: String | Number,
      },
      required: true,
    },
  },

  data() {
    return {
      isShow: this.status.isShow,
    };
  },

  created() {
    document.addEventListener("click", this.documentClick);
    document.addEventListener("wheel", this.documentClick);
  },

  watch: {
    /**
     * Theo dõi thay đổi của props.status
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    status(newValue) {
      this.isShow = newValue.isShow;
    },
  },

  methods: {
    /**
     * Handler bấm vào document
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    documentClick(e) {
      let el = this.$refs.contextMenu;
      let target = e.target;
      if (el) {
        if (el !== target && !el.contains(target)) {
          this.isShow = false;
        }
      }
    },
  },

  unmounted() {
    // important to clean up!!
    document.removeEventListener("click", this.documentClick);
    document.removeEventListener("wheel", this.documentClick);
  },
};
</script>

<style scoped>
/*custom context menu*/
.context-menu {
  position: fixed;
  z-index: 10000;
  width: max-content;
  background: white;
  border-radius: 2px;
  border: 1px solid #babec5;
}
</style>