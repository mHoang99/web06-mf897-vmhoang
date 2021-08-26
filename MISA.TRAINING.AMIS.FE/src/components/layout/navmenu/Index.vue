<template>
  <div class="navbar" :collapsed="collapsed">
    <div class="m-logo-box">
      <div
        v-if="!collapsed"
        class="sprite icon-menu"
        id="toggleNavbar"
        @click="developingToast"
      ></div>
      <div v-if="!collapsed" class="logo"></div>
      <div
        v-if="collapsed"
        class="icon-toggle sprite"
        @click="onToggleNavbarClick"
      />
    </div>

    <div class="navbar-content">
      <router-link
        to="/inDevelopment"
        exact-path
        exact-active-class="in-dev"
        v-tooltip.right="{
          content: 'Tổng quan',
          theme: 'info-tooltip',
        }"
      >
        <div class="nav-item-icon sprite icon-pie-chart"></div>
        <div class="nav-item-text">Tổng quan</div>
      </router-link>
      <router-link
        to="/employee"
        v-tooltip.right="{
          content: 'Tiền mặt',
          theme: 'info-tooltip',
        }"
      >
        <div class="nav-item-icon sprite icon-money-bag"></div>
        <div class="nav-item-text">Nhân viên</div>
      </router-link>

      <router-link
        to="/inDevelopment"
        exact-path
        exact-active-class="in-dev"
        v-tooltip.right="{
          content: 'Tiền gửi',
          theme: 'info-tooltip',
        }"
      >
        <div class="nav-item-icon sprite icon-bank"></div>
        <div class="nav-item-text">Tiền gửi</div>
      </router-link>
      <router-link
        to="/inDevelopment"
        exact-path
        exact-active-class="in-dev"
        v-tooltip.right="{
          content: 'Mua hàng',
          theme: 'info-tooltip',
        }"
      >
        <div class="nav-item-icon sprite icon-bag"></div>
        <div class="nav-item-text">Mua hàng</div>
      </router-link>
      <router-link
        to="/inDevelopment"
        exact-path
        exact-active-class="in-dev"
        v-tooltip.right="{
          content: 'Bán hàng',
          theme: 'info-tooltip',
        }"
      >
        <div class="nav-item-icon sprite icon-cart"></div>
        <div class="nav-item-text">Bán hàng</div>
      </router-link>
      <router-link
        to="/inDevelopment"
        exact-path
        exact-active-class="in-dev"
        v-tooltip.right="{
          content: 'Quản lý hóa đơn',
          theme: 'info-tooltip',
        }"
      >
        <div class="nav-item-icon sprite icon-document"></div>
        <div class="nav-item-text">Quản lý hóa đơn</div>
      </router-link>
      <router-link
        to="/inDevelopment"
        exact-path
        exact-active-class="in-dev"
        v-tooltip.right="{
          content: 'Kho',
          theme: 'info-tooltip',
        }"
      >
        <div class="nav-item-icon sprite icon-warehouse"></div>
        <div class="nav-item-text">Kho</div>
      </router-link>
      <router-link
        to="/inDevelopment"
        exact-path
        exact-active-class="in-dev"
        v-tooltip.right="{
          content: 'Công dụng dụng cụ',
          theme: 'info-tooltip',
        }"
      >
        <div class="nav-item-icon sprite icon-tools"></div>
        <div class="nav-item-text">Công dụng dụng cụ</div>
      </router-link>
      <router-link
        to="/inDevelopment"
        exact-path
        exact-active-class="in-dev"
        v-tooltip.right="{
          content: 'Tài sản cố định',
          theme: 'info-tooltip',
        }"
      >
        <div class="nav-item-icon sprite icon-assets"></div>
        <div class="nav-item-text">Tài sản cố định</div>
      </router-link>
      <router-link
        to="/inDevelopment"
        exact-path
        exact-active-class="in-dev"
        v-tooltip.right="{
          content: 'Thuế',
          theme: 'info-tooltip',
        }"
      >
        <div class="nav-item-icon sprite icon-price-tag"></div>
        <div class="nav-item-text">Giá thành</div>
      </router-link>
      <router-link
        to="/inDevelopment"
        exact-path
        exact-active-class="in-dev"
        v-tooltip.right="{
          content: 'Giá thành',
          theme: 'info-tooltip',
        }"
      >
        <div class="nav-item-icon sprite icon-notebook"></div>
        <div class="nav-item-text">Tổng hợp</div>
      </router-link>
      <router-link
        to="/inDevelopment"
        exact-path
        exact-active-class="in-dev"
        v-tooltip.right="{
          content: 'Tổng hợp',
          theme: 'info-tooltip',
        }"
      >
        <div class="nav-item-icon sprite icon-government"></div>
        <div class="nav-item-text">Ngân sách</div>
      </router-link>
      <router-link
        to="/inDevelopment"
        exact-path
        exact-active-class="in-dev"
        v-tooltip.right="{
          content: 'Báo cáo',
          theme: 'info-tooltip',
        }"
      >
        <div class="nav-item-icon sprite icon-bar-chart"></div>
        <div class="nav-item-text">Báo cáo</div>
      </router-link>
      <router-link
        to="/inDevelopment"
        exact-path
        exact-active-class="in-dev"
        v-tooltip.right="{
          content: 'Phân tich tài chính',
          theme: 'info-tooltip',
        }"
      >
        <div class="nav-item-icon sprite icon-graph"></div>
        <div class="nav-item-text">Phân tích tài chính</div>
      </router-link>
    </div>
  </div>
</template>
<script>
import notificationMixin from "../../../mixins/notification.mixin";

/*
 * Component thanh điều hướng chính
 * Created_by: VMHOANG
 */
export default {
  emits: ["toggleClick"],

  mixins: [notificationMixin],

  props: {
    collapsed: {
      type: Boolean,
      default: false,
    },
  },

  methods: {
    /**
     * Handle bấm nút thay đổi kích thước navbar
     * CREATED_BY: VMHOANG (18/08/2021)
     */
    onToggleNavbarClick() {
      this.$emit("toggleClick");
    },
  },
};
</script>
<style scoped>
@import "./Index.css";
</style>
