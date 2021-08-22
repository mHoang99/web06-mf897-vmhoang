<template lang="">
    <div class="notification-centre" v-show="isVisible">
        <transition-group 
            name="notilist"
        >
            <the-toast
                v-for="noti in notiList"
                :key="noti.id"
                :toastType="noti.type"
                :id="noti.id"
            >
                <p>{{noti.msg}}</p>
            </the-toast>
        </transition-group>

    </div>

</template>
<script>
import { mapGetters } from "vuex";
import TheToast from "../../base/toast/Index.vue";

/*
 * Component chứa thông báo
 * Created_by: VMHOANG
 */
export default {
  name: "NotificationCentre",

  components: {
    TheToast,
  },

  data() {
    return {
      isVisible: true,
    };
  },

  computed: {
    //Danh sách thông báo
    ...mapGetters(["notiList"]),
  },
};
</script>

<style scoped>
.notification-centre {
  position: fixed;
  top: 45px;
  right: 0px;
  padding: 5px 16px 5px 16px;
  z-index: 10000;
  max-height: 90vh;
  display: flex;
  flex-direction: column-reverse;
  gap: 10px;
  flex-wrap: nowrap;
  overflow: hidden;
  /* background-color: yellow; */
}

.notilist-enter-active,
.notilist-leave-active {
  transition: opacity 0.5s ease;
}

.notilist-enter-from,
.notilist-leave-to {
  opacity: 0;
}
</style>