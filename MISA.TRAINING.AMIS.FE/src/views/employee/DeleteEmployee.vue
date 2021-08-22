<template>
  <the-popup
    v-if="status.isShow"
    btn1="Có"
    btn2="Không"
    @close="cancelDelete"
    @confirm="confirmDelete"
    type="confirm-2"
    heading="Xóa bản ghi"
  >
    {{ contentText }}
  </the-popup>
</template>
<script>
import EmployeeService from "../../services/employee.service";
import notificationMixin from "../../mixins/notification.mixin";
import {
  EMPLOYEE_TEXT,
  POPUP_MESSAGE,
  TOAST_DURATION,
  TOAST_MESSAGE,
} from "../../const";

/*
 * Component xóa nhân viên
 * Created_by: VMHOANG
 */
export default {
  emits: ["status-change", "success"],

  mixins: [notificationMixin],
  props: {
    status: {
      isShow: {
        type: Boolean,
      },
      //Mã code của bản ghi muốn xóa
      selectedCode: {
        type: String,
      },
      //Id của bản ghi muốn xóa
      selectedId: {
        type: String,
      },
      required: true,
    },
  },

  computed: {
    //Thông tin chi tiết
    contentText() {
      return POPUP_MESSAGE.DELETE_EMPLOYEE.format(
        EMPLOYEE_TEXT.DISPLAY_NAME,
        this.status.selectedCode
      );
    },
  },

  methods: {
    /**
     * Handle bấm hủy
     * CREATED_BY: VMHOANG (17/07/2021)
     */
    cancelDelete() {
      this.selfClose();
    },

    /**
     * Handle xác nhận
     * CREATED_BY: VMHOANG (17/07/2021)
     */
    async confirmDelete() {
      //Gọi service xóa
      try {
        let res = await EmployeeService.deleteEmployee(this.status.selectedId);
        if (res?.status == 200 && parseInt(res?.data) > 0) {
          this.successToast(
            TOAST_MESSAGE.DELETE_SUCCESS.format(this.status.selectedCode),
            TOAST_DURATION
          );
          this.$emit("success");
        } else {
          this.warningToast(res?.Data.data.UserMsg, TOAST_DURATION);
        }
      } catch (e) {
        console.log(e);
      }
      this.selfClose();
    },
    /**
     * Đóng popup
     * CREATED_BY: VMHOANG (17/07/2021)
     */
    selfClose() {
      this.$emit("status-change", false);
    },
  },
};
</script>
<style lang="">
</style>