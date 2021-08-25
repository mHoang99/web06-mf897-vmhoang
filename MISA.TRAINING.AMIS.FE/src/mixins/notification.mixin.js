import { mapActions } from "vuex";
import { TOAST_DURATION, TOAST_MESSAGE } from "../resources/const";

/**
 * Mixin hiện thông báo
 * CreatedBy: VMHOANG (20/08/2021)
 */
var notificationMixin = {
    methods: {
        //Action của vuex thêm thông báo mới
        ...mapActions({ addNoti: 'addNoti' }),

        /**
         * Hiện thông báo dưới dạng warning
         * @param {*} msg nội dung 
         * @param {*} duration thời gian sống
         * CreatedBy: VMHOANG (20/08/2021)
         */
        warnToast(msg, duration) {
            let type = "warning"
            this.addNoti({
                type,
                msg,
                duration
            })
        },

        /**
         * Hiện thông báo dưới dạng cảnh báo
         * @param {*} msg nội dung 
         * @param {*} duration thời gian sống
         * CreatedBy: VMHOANG (20/08/2021)
         */
        alertToast(msg, duration) {
            let type = "alert"
            this.addNoti({
                type,
                msg,
                duration
            })
        },

        /**
         * Hiện thông báo dưới dạng thông tin
         * @param {*} msg nội dung 
         * @param {*} duration thời gian sống
         * CreatedBy: VMHOANG (20/08/2021)
         */
        infoToast(msg, duration) {
            let type = "info"
            this.addNoti({
                type,
                msg,
                duration
            })
        },

        /**
         * Hiện thông báo dưới dạng thành công
         * @param {*} msg nội dung 
         * @param {*} duration thời gian sống
         * CreatedBy: VMHOANG (20/08/2021)
         */
        successToast(msg, duration) {
            let type = "success"
            this.addNoti({
                type,
                msg,
                duration
            })
        },

        /**
         * Hiện thông báo tính năng đang phát triển
         * CreatedBy: VMHOANG (20/08/2021)
         */
        developingToast() {
            this.infoToast(TOAST_MESSAGE.DEVELOPING, TOAST_DURATION)
        }
    }
}

export default notificationMixin;