<template>
  <div class="app-container">
    <the-nav-menu
      @toggleClick="collapsed = !collapsed"
      :collapsed="collapsed"
    />
    <div class="content-container">
      <the-header
        :collapsed="collapsed"
        @toggleClick="collapsed = !collapsed"
      />
      <div class="content" :collapsed="collapsed">
        <router-view class="router-view" />
      </div>
    </div>
  </div>
  <notification-container />
</template>

<script>
import TheHeader from "./components/layout/header/Index.vue";
import TheNavMenu from "./components/layout/navmenu/Index.vue";
import NotificationContainer from "./components/layout/notification/Index.vue";

/*
 * Component App
 * Created_by: VMHOANG
 */
export default {
  name: "App",
  components: {
    TheHeader,
    TheNavMenu,
    NotificationContainer,
  },

  data() {
    return {
      collapsed: false,
    };
  },
};
</script>

<style>
@import "./App.css";
</style>

<style scoped>
.app-container {
  display: flex;
  box-sizing: border-box;
  position: absolute;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  /* min-width: 1366px; */
}

.content-container {
  flex-grow: 1;
}

.content {
  height: calc(100vh - 48px);
  background-color: #f4f5f8;
  flex: 1;
  border-top: 1px solid #dedede;
  position: relative;
}
</style>