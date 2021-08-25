<template>
  <div class="content-header">
    <div class="title">{{title}}</div>
    <div class="content-feature">
      <base-button type="primary" id="btnAdd" @click="openAddRecord">
        Thêm mới nhân viên
      </base-button>
    </div>
  </div>
</template>

<script>
import { EMPLOYEE_TEXT } from "../../../resources/const";
/*
 * Component header của trang nhân viên
 * Created_by: VMHOANG
 */
export default {
  emits: ["add-btn-click"],

  data() {
    return {
      title: EMPLOYEE_TEXT.TITLE,
    };
  },
  methods: {
    /**
     * Mở record details trạng thái thêm mới
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    openAddRecord () {
      this.$emit("add-btn-click", true, "add");
    },
  },
};
</script>
<style scoped>
@import "./Index.css";
</style>