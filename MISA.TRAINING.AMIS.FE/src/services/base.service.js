import axios from "axios";
import { MESSAGE, TOAST_DURATION } from "../resources/const";

import store from "../store";


/**
 * Base cho gọi api cho nhân viên
 * CREATED_BY: VMHOANG (15/07/2021)
 */
class BaseService {

    constructor() {
        this.BASE_ROUTE = '/v1';
    }

    /**
     * Hàm lấy tất cả 
     * @returns {Promise} res từ api
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    async getAll() {
        try {
            let res = await axios.get(this.BASE_ROUTE);
            return res;
        }
        catch (error) {
            this.catchError(error);
        }
    }

    /**
     * Hàm lấy thông tin theo id
     * @param {String} id 
     * @returns {Promise} res từ api
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    async getById(id) {
        try {
            let res = await axios
                .get(
                    this.BASE_ROUTE + '/' + id,
                )
            return res;
        }
        catch (error) {
            this.catchError(error);
        }
    }


    /**
     * Hàm tạo mới
     * @param {Object} data 
     * @returns {Promise} res từ api
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    async create(data) {
        try {
            let res = await axios
                .post(
                    this.BASE_ROUTE,
                    data
                )
            return res;
        }
        catch (error) {
            this.catchError(error);
        }
    }


    /**
     * Hàm xóa
     * @param {String} id 
     * @returns {Promise} res từ api
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    async delete(id) {
        try {
            let res = await axios
                .delete(
                    this.BASE_ROUTE + '/' + id,
                )
            return res;
        }
        catch (error) {
            this.catchError(error);
        }
    }


    /**
     * Hàm sửa
     * @param {String} id 
     * @param {Object} data 
     * @returns {Promise} res từ api
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    async edit(id, data) {
        try {
            let res = await axios
                .put(
                    axios.defaults.baseURL + this.BASE_ROUTE + '/' + id,
                    data,
                )
            return res;
        }
        catch (error) {
            this.catchError(error);
        }
    }

    /**
     * Handle exception
     * @param {*} error 
     */
    catchError(error) {
        store.dispatch("addNoti", {
            type: "alert",
            msg: error.response?.data?.UserMsg ?? MESSAGE.EXCEPTION,
            duration: TOAST_DURATION
        })
    }
}

export default BaseService;
