import axios from "axios";
import { TOAST_DURATION } from "../const";

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
            return axios.get(this.BASE_ROUTE);
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
            return axios
                .get(
                    this.BASE_ROUTE + '/' + id,
                )
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
            return axios
                .post(
                    this.BASE_ROUTE,
                    data
                )
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
            return axios
                .delete(
                    this.BASE_ROUTE + '/' + id,
                )
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
            return axios
                .put(
                    axios.defaults.baseURL + this.BASE_ROUTE + '/' + id,
                    data,
                )
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
        // console.log(error.response)
        if (error.response) {
            store.dispatch("addNoti", {
                type: "alert",
                msg: error.response.data.UserMsg,
                duration: TOAST_DURATION
            })
        }
    }

}

export default BaseService;
