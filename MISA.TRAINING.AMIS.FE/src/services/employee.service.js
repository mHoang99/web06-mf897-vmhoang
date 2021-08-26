import axios from "axios";
import BaseService from "./base.service";


/**
 * Service cho gọi api cho nhân viên
 * CREATED_BY: VMHOANG (15/07/2021)
 */
class EmployeeService extends BaseService {

    constructor() {
        super()
        this.BASE_ROUTE = '/v1/Employees';
        this.FILTER = '/FilterPaging';
        this.GET_NEW = '/NewEmployeeCode';
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
        try {
            let res = await axios
                .get(
                    this.BASE_ROUTE + this.FILTER,
                    {
                        params: {
                            pageSize: pageSize,
                            pageNumber: pageNumber,
                            employeeFilter: employeeFilter,
                        }
                    }
                )
            return res;
        }
        catch (error) {
            this.catchError(error);
        }
    }


    /**
     * Hàm lấy mã nhân viên mới
     * CREATED_BY: VMHOANG (15/07/2021)
     * @returns {Promise} res từ api
     */
    async getNewEmployeeCode() {
        try {
            let res = await axios
                .get(
                    this.BASE_ROUTE + this.GET_NEW
                )
            return res;
        }
        catch (error) {
            this.catchError(error);
        }
    }
}

export default new EmployeeService();
