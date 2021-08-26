import axios from "axios";
import Utils from "../common/utils";
import pluralize from "pluralize";
import store from "../store";
import { MESSAGE, TOAST_DURATION } from "../resources/const";

/**
 * Service lấy các giá trị của dropdown và combobox
 * CREATED_BY: VMHOANG (15/07/2021)
 */
class DropdownService {

    /**
     * Các giá trị mặc định của 1 số dropdown và combobox 
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    DROPDOWN_DICTIONARY = {

    }

    /**
     * Lấy dữ liệu cho dropdown bằng fieldname
     * @param {String} fieldName 
     * @returns {Promise} response từ api
     */
    async getByFieldName(fieldName) {
        try {
            let res = await axios
                .get("/v1/" + Utils.pascalize(pluralize(fieldName)))
            return res;
        }
        catch (error) {
            store.dispatch("addNoti", {
                type: "alert",
                msg: error.response?.data?.UserMsg ?? MESSAGE.EXCEPTION,
                duration: TOAST_DURATION
            })
        }
    }


    /**
     * Chuyển res nhận được từ service thành {text, value}
     * @param {*} fieldName tên của input
     * @param {*} data  data đầu vào
     * @returns {Array} mảng dữ liệu đã được format 
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    castToDict(fieldName, data) {
        let fetchedData = [];
        //Chưa có sẵn trong dictionary 
        data.forEach((item) => {
            fetchedData.push({
                value: item[Utils.pascalize(fieldName) + "Id"],
                text: item[Utils.pascalize(fieldName) + "Name"],
                data: item
            });
        });

        return fetchedData;
    }
}

export default new DropdownService();
