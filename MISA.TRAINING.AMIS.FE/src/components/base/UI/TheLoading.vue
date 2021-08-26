<template>
  <div class="loader-container" v-if="show">
    <div class="loader">
      <img src="../../../assets/loading.svg" alt="" />
    </div>
  </div>
</template>

<script>
/*
 * Component hiển thị loading
 * Created_by: VMHOANG
 */
export default {
  props: {
    show: {
      type: Boolean,
      default: false,
    },
  },
};
</script>

<style scoped>
.loader-container {
  position: absolute;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  opacity: 0.5;
  background-color: white;
  z-index: 50;
  /*display: none;*/
}

.loader {
  top: 50%;
  left: 50%;
  width: 32px;
  height: 32px;
  transform: translateX(-50%) translateY(-50%);
  position: absolute;
}

.loader img {
  animation: spin 2s linear infinite;
}
</style>