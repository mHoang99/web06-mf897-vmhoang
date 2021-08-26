<template class="content">
  <employee-header @add-btn-click="changeFormStatus" />
  <div class="content-body">
    <employee-filter-bar
      @reload-btn-click="loadData"
      @filter-update="onFilterUpdate"
      :record-filter="recordFilter"
    />
    <base-table
      :table-data="table"
      :is-loading="isReloading"
      paddingLeft="30px"
      paddingRight="30px"
      @edit-btn-click="changeFormStatus"
      @delete-btn-click="changeDeleteStatus"
      @clone-btn-click="changeFormStatus"
    />
  </div>
  <page-content-pagination
    @paging-update="onPagingUpdate"
    :paging="paging"
    v-show="table.data.length > 0"
  />
  <div class="content-outer-right" />
  <employee-form
    :status="RecordDetailsStatus"
    @status-change="changeFormStatus"
    @success="loadData"
  />

  <teleport to="#app">
    <delete-employee
      @status-change="changeDeleteStatus"
      :status="deleteStatus"
      @success="loadData"
    ></delete-employee>
  </teleport>
</template>
<script>
import EmployeeFilterBar from "./filterbar/Index.vue";
import EmployeeHeader from "./header/Index.vue";
import PageContentPagination from "../../components/layout/pagination/Index.vue";
import DeleteEmployee from "./DeleteEmployee.vue";
import EmployeeForm from "./EmployeeForm.vue";
import BaseTable from "../../components/base/table/Index.vue";
import EmployeeService from "../../services/employee.service";
import { mapActions } from "vuex";

/*
 * Component trang nhân viên
 * Created_by: VMHOANG
 */
export default {
  inheritAttrs: false,
  components: {
    EmployeeFilterBar,
    EmployeeHeader,
    PageContentPagination,
    BaseTable,
    DeleteEmployee,
    EmployeeForm,
  },
  data() {
    return {
      // trạng thái của chi tiết bản ghi
      RecordDetailsStatus: {
        isShow: false,
        formType: "add",
        selectedId: "",
      },
      // trạng thái của dialog xóa
      deleteStatus: {
        isShow: false,
        selectedCode: "",
        selectedId: "",
      },

      isReloading: true,

      //thiết lập cho bảng
      table: {
        columns: [
          {
            id: "EmployeeCodeHead",
            style: "min-width: 150px",
            fieldname: "EmployeeCode",
            title: "Mã nhân viên",
          },
          {
            id: "EmployeeNameHead",
            style: "min-width: 200px",
            fieldname: "EmployeeName",
            title: "Họ và tên",
          },
          {
            id: "GenderHead",
            style: "min-width: 125px",
            fieldname: "Gender",
            formattype: "gender",
            title: "Giới tính",
          },
          {
            id: "DateOfBirthHead",
            style: "min-width: 120px",
            fieldname: "DateOfBirth",
            formattype: "ddmmyyyy",
            title: "Ngày sinh",
            position: "text-align-center",
          },
          {
            id: "EmployeePositionHead",
            style: "min-width: 150px",
            fieldname: "EmployeePosition",
            title: "Vị trí",
          },
          {
            id: "DepartmentNameHead",
            style: "min-width: 150px",
            fieldname: "DepartmentName",
            title: "Phòng ban",
          },
          {
            id: "AddressHead",
            style: "min-width: 200px; max-width: 200px;",
            fieldname: "Address",
            title: "Địa chỉ",
            position: "text-overflow-ellipsis",
          },
          {
            id: "PhoneNumberHead",
            style: "min-width: 160px",
            fieldname: "PhoneNumber",
            title: "Điện thoại di động",
          },
          {
            id: "TelephoneNumberHead",
            style: "min-width: 160px",
            fieldname: "TelephoneNumber",
            title: "Điện thoại cố định",
          },
          {
            id: "EmailHead",
            style: "min-width: 250px",
            fieldname: "Email",
            title: "Email",
          },
          {
            id: "BacnkAccountNumberHead",
            style: "min-width: 180px",
            fieldname: "BankAccountNumber",
            title: "Tài khoản ngân hàng",
          },
          {
            id: "BankNameHead",
            style: "min-width: 160px",
            fieldname: "BankName",
            title: "Ngân hàng",
          },
          {
            id: "BankBranchNameHead",
            style: "min-width: 200px",
            fieldname: "BankBranchName",
            title: "Chi nhánh ngân hàng",
          },
          {
            id: "CreatedDateHead",
            style: "min-width: 120px",
            fieldname: "CreatedDate",
            formattype: "ddmmyyyy",
            title: "Ngày tạo",
            position: "text-align-center",
          },
        ],
        data: [],
      },

      recordFilter: {
        searchVal: ""
      },

      paging: {
        currentPage: 1,
        totalPage: 0,
        totalRecord: 0,
        pageSize: 20,
        numberOfButton: 3,
      },
    };
  },

  created() {
    this.fetchDropdownData("Department");
    this.loadData();
  },

  watch: {
    /**
     * Theo dõi phân trang thay đổi
     * CREATED_BY: VMHOANG
     */
    async paging(newValue, oldValue) {
      if (
        newValue.currentPage !== oldValue.currentPage ||
        newValue.pageSize !== oldValue.pageSize
      ) {
        await this.loadData();
      }
    },

    /**
     * Theo dõi filter thay đổi
     * CREATED_BY: VMHOANG
     */
    async recordFilter(newValue, oldValue) {
      if (JSON.stringify(oldValue) !== JSON.stringify(newValue)) {
        await this.loadData();
        this.paging = {
          ...this.paging,
          currentPage: 1,
        };
      }
    },
  },

  methods: {
    ...mapActions(["fetchDropdownData"]),

    /**
     * Theo dõi filter thay đổi
     * CREATED_BY: VMHOANG
     */
    async loadData() {
      this.isReloading = true;
      this.table.data = [];

      try {
        //gọi API lấy dữ liệu phân trang
        let res = await EmployeeService.filter(
          this.paging.pageSize,
          this.paging.currentPage,
          this.recordFilter.searchVal,
          this.recordFilter.departmentId,
          this.recordFilter.positionId
        );

        //Xử lý
        if (res?.status == 200) {
          //Kết quả trả về đúng
          this.table.data = [...res.data.Data];
          this.paging = {
            ...this.paging,
            totalPage: res.data.TotalPage,
            totalRecord: res.data.TotalRecord,
            currentPage:
              this.paging.currentPage <= res.data.TotalPage
                ? this.paging.currentPage
                : 1,
          };
        } else {
          //Kết quả trả về không đúng 
          this.table.data = [];
          this.paging = {
            ...this.paging,
            totalPage: 0,
            totalRecord: 0,
            currentPage: 1,
          };
        }
      } catch (e) {
        console.log(e);
      }
      this.isReloading = false;
    },

    /**
     * sửa trạng thái form
     * @param {boolean} isShow trạng thái đóng mở
     * @param {string} formType add | edit | clone
     * @param {object} selectedRow Dữ liệu hàng vừa chọn
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    changeFormStatus(isShow, formType = "add", selectedRow = {}) {
      this.RecordDetailsStatus = {
        isShow: isShow,
        formType: formType,
        selectedId: selectedRow.EmployeeId,
      };
    },

    /**
     * sửa trạng thái popup xóa
     * @param {boolean} isShow trạng thái đóng mở
     * @param {object} selectedRow Dữ liệu hàng vừa chọn
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    changeDeleteStatus(isShow, selectedRow = {}) {
      this.deleteStatus = {
        isShow: isShow,
        selectedCode: selectedRow.EmployeeCode,
        selectedId: selectedRow.EmployeeId,
      };
    },

    /**
     * Cập nhật paging
     * @param {object} value
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    onPagingUpdate(value) {
      this.paging = {
        ...value,
      };
    },

    /**
     * Cập nhật filter
     * @param {object} value
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    onFilterUpdate(value) {
      this.recordFilter = {
        ...value,
      };
    },
  },
};
</script>

<style scoped>
.content-body {
  overflow: scroll;
  position: absolute;
  bottom: 0;
  right: 0;
  left: 16px;
  top: 0;
  padding: 68px 16px 46px 0;
  scroll-behavior: smooth;
  background-color: white;
}

.content .content-outer-right {
  position: absolute;
  right: 10px;
  width: 16px;
  top: 0;
  bottom: 10px;
  background-color: #f4f5f8;
  z-index: 29;
}
</style>