import axios from "axios";
import { TOAST_DURATION } from "../const";

import store from "../store";


/**
 * Service cho gọi api cho nhân viên
 * CREATED_BY: VMHOANG (15/07/2021)
 */
class EmployeeService {

    constructor() {
        this.BASE_ROUTE = '/v1/Employees';
    }

    /**
     * Hàm lấy tất cả nhân viên
     * @returns {Promise} res từ api
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    async getAll() {
        return axios
            .get(axios.defaults.baseURL + this.BASE_ROUTE)
            .then(response => {
                return response;
            })
            .catch(error => {
                this._catchError(error);
            })
    }

    /**
     * Hàm filter nhân viên
     * @param {Number} pageSize kích thước trang
     * @param {Number} pageNumber số trang
     * @param {String} employeeFilter 
     * @returns {Promise} res từ api
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    async filter(
        pageSize = 10,
        pageNumber = 1,
        employeeFilter = "",
    ) {
        return axios
            .get(
                axios.defaults.baseURL + this.BASE_ROUTE + '/FilterPaging',
                {
                    params: {
                        pageSize: pageSize,
                        pageNumber: pageNumber,
                        employeeFilter: employeeFilter,
                    }
                }
            )
            .then(response => {
                return response;
            })
            .catch(error => {
                this._catchError(error);
            })
    }


    /**
     * Hàm lấy mã nhân viên mới
     * CREATED_BY: VMHOANG (15/07/2021)
     * @returns {Promise} res từ api
     */
    async getNewEmployeeCode() {
        return axios
            .get(
                axios.defaults.baseURL + this.BASE_ROUTE + '/NewEmployeeCode'
            )
            .then(response => {
                return response;
            })
            .catch(error => {
                this._catchError(error);
            })
    }


    /**
     * Hàm lấy thông tin nhân viên theo id
     * @param {String} id 
     * @returns {Promise} res từ api
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    async getEmployeeById(id) {
        return axios
            .get(
                axios.defaults.baseURL + this.BASE_ROUTE + '/' + id,
            )
            .then(response => {
                return response;
            })
            .catch(error => {
                this._catchError(error);
            })
    }


    /**
     * Hàm tạo nhân viên mới
     * @param {Object} data 
     * @returns {Promise} res từ api
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    async createEmployee(data) {
        return axios
            .post(
                axios.defaults.baseURL + this.BASE_ROUTE,
                data
            )
            .then(response => {
                return response;
            })
            .catch(error => {
                this._catchError(error);
            })
    }


    /**
     * Hàm xóa nhân viên
     * @param {String} id 
     * @returns {Promise} res từ api
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    async deleteEmployee(id) {
        return axios
            .delete(
                axios.defaults.baseURL + this.BASE_ROUTE + '/' + id,
            )
            .then(response => {
                return response;
            })
            .catch(error => {
                this._catchError(error);

            })
    }


    /**
     * Hàm sửa nhân viên
     * @param {String} id 
     * @param {Object} data 
     * @returns {Promise} res từ api
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    async editEmployee(id, data) {
        return axios
            .put(
                axios.defaults.baseURL + this.BASE_ROUTE + '/' + id,
                data,
            )
            .then(response => {
                return response;
            })
            .catch(error => {
                this._catchError(error);
            })
    }

    _catchError(error) {
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

export default new EmployeeService();
