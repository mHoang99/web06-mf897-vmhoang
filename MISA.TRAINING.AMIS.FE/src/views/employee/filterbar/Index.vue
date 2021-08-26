<template lang="">
    <div class="filter-bar">
        <base-input
            icon="icon-search"
            placeholder="Tìm kiếm theo mã, tên, số điện thoại"
            type="text"
            name=""
            value=""
            v-model.output=searchVal
            @keydown.enter="onInputConfirm"
            @blur="onInputConfirm"
            ref="inputSearchBox"
        />
        <div 
        class="icon-refresh sprite btn-refresh" 
        @click="$emit('reload-btn-click')"
        v-tooltip.top="{
          content: 'Tải lại',
          theme: 'info-na-tooltip',
        }"
        />
    </div>
</template>
<script>
/*
 * Component thanh lọc của trang nhân viên
 * Created_by: VMHOANG
 */
export default {
  emits: ["reload-btn-click", "filter-update"],

  props: {
    recordFilter: {
      searchVal: {
        type: String,
        default: "",
      },
    },
  },

  data() {
    return {
      searchVal: "",
      timeout: null,
    };
  },

  watch: {
    searchVal(newValue) {
      clearTimeout(this.timeout);
      this.timeout = setTimeout(() => {
        this.$emit("filter-update", {
          ...this.recordFilter,
          searchVal: newValue,
        });
      }, 700);
    },
  },

  methods: {
    /**
     * Handler khi ấn enter hoặc blur ô input search
     * CREATED_BY: VMHOANG (17/07/2021)
     */
    onInputConfirm() {
      this.timeout = null;
      this.$emit("filter-update", {
        ...this.recordFilter,
        searchVal: this.searchVal,
      });
    },
  },
};
</script>
<style scoped>
@import "./Index.css";
</style>