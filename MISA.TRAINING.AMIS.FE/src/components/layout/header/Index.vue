<template lang="">
    <div class="header">
            <div>
                <div 
                    v-if="!collapsed" 
                    class="icon-toggle sprite"
                    @click="onToggleNavbarClick"
                />
                <div 
                    class="header-branch-name"  
                    @click="developingToast"
                >
                    công ty cổ phần Misa
                </div>
                <div 
                    class="header-branch-option sprite icon-chevron-down"  
                    @click="developingToast"
                />
            </div>
            <div class="account-info" @click="developingToast">
                <div class="account-bell sprite icon-bell"></div>
                <div class="account-avatar"></div>
                <div class="account-name">Vũ Minh Hoàng</div>
                <div class="account-option sprite icon-chevron-down-small"></div>
            </div>
        </div>
</template>
<script>
import notificationMixin from "../../../mixins/notification.mixin";
/*
 * Component header chính
 * Created_by: VMHOANG
 */
export default {
  emits: ["toggleClick"],

  mixins: [notificationMixin],

  props: {
    collapsed: {
      type: Boolean,
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