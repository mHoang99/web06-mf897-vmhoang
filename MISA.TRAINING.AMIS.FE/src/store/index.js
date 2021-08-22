import { createStore } from "vuex";
import notiModule from "./modules/notifications"
import dropdownModule from "./modules/dropdown";


/**
 * Hàm khởi tạo vuex store cho application
 * CREATEDBY: VMHOANG (21/07/2021)
 */
const store = createStore({
    modules: {
        notification: notiModule,
        dropdownStore: dropdownModule
    }
})

export default store