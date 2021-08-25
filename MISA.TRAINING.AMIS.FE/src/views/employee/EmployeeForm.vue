<template>
  <the-modal
    v-if="status.isShow"
    :open="true"
    :loading="isLoading"
    class="details-modal"
  >
    <!-- ------------------------------HEADER------------------------------ -->
    <template #header>
      <div class="form-header-container">
        <span>{{ title }}</span>
        <div>
          <input type="checkbox" name="isCustomer" />
          <label for="vehicle1">Là khách hàng</label>
        </div>
        <div>
          <input type="checkbox" name="IsProvider" />
          <label for="vehicle2">Là nhà cung cấp</label>
        </div>
      </div>
      <div class="form-header-options">
        <div
          class="sprite icon-question-mark form-option"
          @click="developingToast"
          v-tooltip.bottom="{
            content: 'Giúp',
            theme: 'info-tooltip',
          }"
        ></div>
        <div
          class="sprite icon-x form-option"
          @click="closeFormWithCheck"
          v-tooltip.bottom="{
            content: 'Đóng (ESC)',
            theme: 'info-tooltip',
          }"
        ></div>
      </div>
    </template>
    <!-- ------------------------------CONTENT------------------------------ -->
    <template #content>
      <div class="form-block-1">
        <the-label :required="true" label="Mã">
          <base-input
            ref="inputEmployeeCode"
            id="txtEmployeeCode"
            type="text"
            fieldType="employeeCode"
            displayName="Mã"
            value=""
            placeholder=""
            :required="true"
            v-model.output="employeeDetails.EmployeeCode"
          />
        </the-label>

        <the-label :required="true" label="Tên">
          <base-input
            ref="inputEmployeeName"
            id="txtEmployeeName"
            type="text"
            displayName="Tên"
            fieldType="name"
            value=""
            placeholder=""
            :required="true"
            v-model.output="employeeDetails.EmployeeName"
          />
        </the-label>

        <the-label label="Đơn vị" :required="true">
          <department-combo-box
            id="cbxDepartment"
            ref="cbxDepartment"
            fieldName="Department"
            displayName="Đơn vị"
            :required="true"
            v-model.output="employeeDetails.DepartmentId"
          />
        </the-label>

        <the-label label="Chức danh">
          <base-input
            ref="inputPositon"
            id="txtPosition"
            type="text"
            displayName="Chức danh"
            value=""
            placeholder=""
            v-model.output="employeeDetails.EmployeePosition"
          />
        </the-label>
      </div>
      <div class="form-block-2">
        <the-label label="Ngày sinh">
          <date-input
            ref="inputDateOfBirth"
            id="dtDateOfBirth"
            displayName="Ngày sinh"
            dateFormat="DD/MM/YYYY"
            placeholder="DD/MM/YYYY"
            v-model.output="employeeDetails.DateOfBirth"
          />
        </the-label>

        <the-label label="Giới tính">
          <div class="field-gender">
            <input
              type="radio"
              id="html"
              name="Gender"
              v-model="employeeDetails.Gender"
              :value="1"
            />
            <label :for="1">Nam</label>
            <input
              type="radio"
              id="css"
              name="Gender"
              v-model="employeeDetails.Gender"
              :value="0"
            />
            <label :for="0">Nữ</label>
            <input
              type="radio"
              id="css"
              name="Gender"
              v-model="employeeDetails.Gender"
              :value="2"
            />
            <label :for="2">Khác</label>
          </div>
        </the-label>

        <the-label label="Số CMND">
          <base-input
            ref="inputIdentityNumber"
            id="txtIdentityNumber"
            type="text"
            fieldType="number"
            value=""
            displayName="Số CMND"
            placeholder=""
            v-model.output="employeeDetails.IdentityNumber"
          />
        </the-label>

        <the-label label="Ngày cấp">
          <date-input
            ref="inputIdentityDate"
            id="dtIdentityDate"
            displayName="Ngày cấp"
            dateFormat="DD/MM/YYYY"
            placeholder="DD/MM/YYYY"
            v-model.output="employeeDetails.IdentityDate"
          />
        </the-label>

        <the-label label="Nơi cấp">
          <base-input
            ref="inputIdentityPlace"
            id="txtIdentityPlace"
            displayName="Nơi cấp"
            type="text"
            value=""
            placeholder=""
            v-model.output="employeeDetails.IdentityPlace"
          />
        </the-label>
      </div>
      <div class="form-block-3">
        <the-label label="Địa chỉ">
          <base-input
            ref="inputAddress"
            id="txtAddress"
            displayName="Địa chỉ"
            type="text"
            value=""
            placeholder=""
            v-model.output="employeeDetails.Address"
          />
        </the-label>

        <the-label label="ĐT di động">
          <base-input
            ref="inputPhoneNumber"
            id="txtPhoneNumber"
            type="text"
            displayName="ĐT di động"
            fieldType="phone"
            value=""
            placeholder=""
            v-model.output="employeeDetails.PhoneNumber"
          />
        </the-label>

        <the-label label="ĐT cố định">
          <base-input
            ref="inputTelephoneNumber"
            id="txtTelephoneNumber"
            displayName="ĐT cố định"
            type="text"
            fieldType="phone"
            value=""
            placeholder=""
            v-model.output="employeeDetails.TelephoneNumber"
          />
        </the-label>

        <the-label label="Email">
          <base-input
            ref="inputEmail"
            id="txtEmail"
            type="text"
            displayName="Email"
            fieldType="email"
            value=""
            placeholder=""
            v-model.output="employeeDetails.Email"
          />
        </the-label>

        <the-label label="Tài khoản ngân hàng">
          <base-input
            ref="inputBankAccountNumber"
            id="txtBankAccountNumber"
            type="text"
            displayName="Tài khoản ngân hàng"
            fieldType="number"
            value=""
            placeholder=""
            v-model.output="employeeDetails.BankAccountNumber"
          />
        </the-label>

        <the-label label="Tên ngân hàng">
          <base-input
            ref="inputBankName"
            id="txtBankName"
            displayName="Tên ngân hàng"
            type="text"
            value=""
            placeholder=""
            v-model.output="employeeDetails.BankName"
          />
        </the-label>

        <the-label label="Chi nhánh">
          <base-input
            ref="inputBankBranchName"
            id="txtBankBranchName"
            displayName="Chi nhánh"
            type="text"
            value=""
            placeholder=""
            v-model.output="employeeDetails.BankBranchName"
          />
        </the-label>
      </div>
    </template>
    <!-- ------------------------------FOOTER------------------------------ -->
    <template #footer>
      <base-button
        type="secondary"
        id="btnDialogCancel"
        @click="closeForm"
        v-tooltip.top="{
          content: 'Hủy',
          theme: 'info-na-tooltip',
        }"
      >
        Hủy
      </base-button>
      <div>
        <base-button
          type="secondary"
          id="btnDialogSave"
          @click="saveForm"
          v-tooltip.top="{
            content: 'Cất',
            theme: 'info-na-tooltip',
          }"
        >
          Cất
        </base-button>
        <base-button
          type="primary"
          id="btnDialogSaveAndCreate"
          @click="saveFormAndCreate"
          v-tooltip.top="{
            content: 'Cất và thêm',
            theme: 'info-na-tooltip',
          }"
        >
          Cất và thêm
        </base-button>
      </div>
    </template>
  </the-modal>
  <!-- ------------------------------POPUP------------------------------ -->
  <teleport to="#app">
    <the-popup
      v-if="saveChangesPopupShow"
      btn1="Có"
      btn2="Hủy"
      btn3="Không"
      @close="closeSaveChangesPopup"
      @confirm="confirmSaveChangesPopup"
      @cancel="cancelSaveChangesPopup"
      type="confirm-1"
    >
      {{ saveChangesPopupMessage }}
    </the-popup>

    <the-popup
      v-if="invalidFieldPopupShow"
      btn1="Đóng"
      @confirm="onInvalidFieldPopupConfirm"
      type="alert"
    >
      {{ invalidFieldPopupMessage }}
    </the-popup>

    <the-popup
      v-if="serverResponsePopupShow"
      btn1="Đồng ý"
      @confirm="serverResponsePopupShow = false"
      type="warning"
    >
      {{ serverResponsePopupMessage }}
    </the-popup>
  </teleport>
</template>

<script>
import EmployeeService from "../../services/employee.service";
import DepartmentComboBox from "../../components/base/combobox/department/Index.vue";
import Formater from "../../common/format";
import notificationMixin from "../../mixins/notification.mixin";
import { EMPLOYEE_TEXT, POPUP_MESSAGE, TOAST_DURATION } from "../../const";

/*
 * Component form nhân viên
 * Created_by: VMHOANG
 */
export default {
  components: {
    DepartmentComboBox,
    // DatePicker,
  },

  emits: ["status-change", "success"],

  mixins: [notificationMixin],

  props: {
    status: {
      isShow: {
        type: Boolean,
      },
      //add | edit
      formType: {
        type: String,
      },
      //Id của bản ghi được chọn
      selectedId: {
        type: String,
      },
      required: true,
    },
  },

  data() {
    return {
      title: EMPLOYEE_TEXT.FORM_TITLE,
      //hiện  popup xác nhận
      saveChangesPopupShow: false,
      //hiện popup báo lỗi trường
      invalidFieldPopupShow: false,
      //hiện popup báo lỗi từ server
      serverResponsePopupShow: false,
      //thông báo lỗi
      invalidFieldPopupMessage: "",
      //thông báo lỗi
      serverResponsePopupMessage: "",
      //thông báo có thay đổi
      saveChangesPopupMessage: POPUP_MESSAGE.FORM_CHANGED,
      //thông tin chi tiết bản ghi
      record: {},
      //Các input refs không hợp lệ
      invalidRef: [],
      //Đang loading
      isLoading: false,

      originalEmployeeDetails: {},

      employeeDetails: {
        EmployeeCode: "",
        EmployeeName: "",
        DepartmentId: "",
        EmployeePosition: "",
        DateOfBirth: "",
        Gender: "",
        IdentityNumber: "",
        IdentityDate: "",
        IdentityPlace: "",
        Address: "",
        PhoneNumber: "",
        TelephoneNumber: "",
        Email: "",
        BankAccountNumber: "",
        BankName: "",
        BankBranchName: "",
      },
    };
  },

  created() {
    //add event listeners vào document
    document.removeEventListener("keyup", this.documentKeyup);
    document.addEventListener("keyup", this.documentKeyup);
    //preload radio img
    const image = new Image();
    image.src = "../assets/icon/radio.svg";
  },

  watch: {
    /**
     * Theo dõi status thay đổi
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    async status(newValue) {
      if (newValue.isShow) {
        this.resetDetails();

        switch (newValue.formType) {
          case "add":
            await this.addForm();
            break;
          case "edit":
            await this.editForm();
            break;
          case "clone":
            await this.cloneForm();
            break;
          default:
            break;
        }

        this.originalEmployeeDetails = { ...this.employeeDetails };
      }
    },
  },

  methods: {
    /**
     * Khởi chạy add form
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    async addForm() {
      this.isLoading = true;
      try {
        //Gọi API lấy code mới
        let resNewCode = await EmployeeService.getNewEmployeeCode();
        this.employeeDetails.EmployeeCode = resNewCode?.data;
        this.$refs.inputEmployeeCode.$refs.input.focus();
      } catch (e) {
        console.log(e);
      }
      this.isLoading = false;
    },

    /**
     * Khởi chạy edit form
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    async editForm() {
      this.isLoading = true;
      try {
        //Gọi API lấy thông tin nhân viên hiện tại
        if (this.status.selectedId) {
          let resDetails = await EmployeeService.getById(
            this.status.selectedId
          );
          this.bindDetails(resDetails?.data);
        }
        this.$refs.inputEmployeeCode.$refs.input.focus();
      } catch (e) {
        console.log(e);
      }
      this.isLoading = false;
    },

    /**
     * Khởi chạy clone form
     * CREATED_BY: VMHOANG (20/08/2021)
     */
    async cloneForm() {
      this.isLoading = true;
      try {
        if (this.status.selectedId) {
          //goị API lấy dữ liệu bản ghi được chọn
          let resDetails = await EmployeeService.getById(
            this.status.selectedId
          );

          //gọi API lấy dữ liệu bản ghi mới
          let resNewCode = await EmployeeService.getNewEmployeeCode();

          resDetails.data.EmployeeCode = resNewCode.data;
          this.bindDetails(resDetails.data);
        }
        this.$refs.inputEmployeeCode.$refs.input.focus();
      } catch (e) {
        console.log(e);
      }
      this.isLoading = false;
    },

    closeForm() {
      this.$emit("status-change", false);
    },

    /**
     * Đóng form
     * CREATED_BY: VMHOANG (17/07/2021)
     */
    closeFormWithCheck() {
      let showPopup = false;

      //Kiểm tra form bị thay đổi
      Object.entries(this.originalEmployeeDetails).forEach(([key]) => {
        if (this.originalEmployeeDetails[key] !== this.employeeDetails[key]) {
          showPopup = true;
        }
      });

      if (showPopup) {
        this.saveChangesPopupShow = showPopup;
      } else {
        this.closeForm();
      }
    },

    /**
     * Đóng popup xác nhận
     * CREATED_BY: VMHOANG (17/07/2021)
     */
    closeSaveChangesPopup() {
      this.saveChangesPopupShow = false;
    },

    /**
     * xác nhận popup
     * CREATED_BY: VMHOANG (17/07/2021)
     */
    async confirmSaveChangesPopup() {
      this.closeSaveChangesPopup();
      await this.saveForm();
    },

    cancelSaveChangesPopup() {
      this.closeSaveChangesPopup();
      this.closeForm();
    },

    /**
     * Thông báo trường không hợp lệ
     * @param {String} message
     * CREATED_BY: VMHOANG (20/07/2021)
     */
    popupInvalidFields(message) {
      this.invalidFieldPopupMessage = message;
      this.invalidFieldPopupShow = true;
    },

    onInvalidFieldPopupConfirm() {
      this.invalidFieldPopupShow = false;
      //foccus sai
      this.invalidRef[0].$el.querySelector("input").focus();
    },

    /**
     * Thông báo trường không hợp lệ
     * @param {String} message
     * CREATED_BY: VMHOANG (20/07/2021)
     */
    popupServerResponse(message) {
      this.serverResponsePopupMessage = message;
      this.serverResponsePopupShow = true;
    },

    /**
     * Thông báo thành công
     * CREATED_BY: VMHOANG (20/07/2021)
     */
    notiChangeSucceed() {
      let msg = "";
      switch (this.status.formType) {
        case "add":
        case "clone":
          msg = "Thêm bản ghi mới thành công";
          break;
        case "edit":
          msg = "Thay đổi bản ghi thành công";
          break;
        default:
          break;
      }

      this.successToast(msg, TOAST_DURATION);
    },

    /**
     * Thông báo thất bại
     * @param {String} message
     * CREATED_BY: VMHOANG (20/07/2021)
     */
    notiChangeFailed(message) {
      this.warnToast(message, TOAST_DURATION);
    },

    /**
     * Reset tất cả input
     * CREATED_BY: VMHOANG (19/07/2021)
     */
    resetDetails() {
      Object.entries(this.employeeDetails).forEach(([key]) => {
        this.employeeDetails[key] = "";
      });
    },

    /**
     * Bind dữ liệu vào input
     * @param {object} data
     * CREATED_BY: VMHOANG (18/07/2021)
     */
    bindDetails(data) {
      //Loop qua thông tin nhân viên
      Object.entries(this.employeeDetails ?? {}).forEach(([key]) => {
        switch (key) {
          case "DateOfBirth":
          case "IdentityDate":
            this.employeeDetails[key] = Formater.formatDateForInput(data[key]);
            break;
          default:
            this.employeeDetails[key] = data[key];
        }
      });
    },

    /**
     * Lưu bản ghi và mở thêm form
     * CREATED_BY: VMHOANG (18/07/2021)
     */
    async saveFormAndCreate() {
      if (await this.saveForm()) {
        this.$emit("status-change", true, "add");
      }
    },

    /**
     * Lưu bản ghi
     * CREATED_BY: VMHOANG (18/07/2021)
     */
    async saveForm() {
      this.invalidRef = [];

      //Loop qua thông tin nhân viên
      Object.entries(this.$refs).forEach(([key, el]) => {
        if (key.startsWith("input") || key.startsWith("cbx")) {
          let value = el.$data.outputValue;

          this.record[el.$attrs.name] = value;

          el.$el.querySelector("input").focus();
          el.$el.querySelector("input").blur();

          if (!(el.$data.selfValid && el.$data.selfRequiredValid)) {
            this.invalidRef = [...this.invalidRef, el];
          }
        }
      });
      if (this.invalidRef.length > 0) {
        let msg =
          this.invalidRef[0].tooltip ?? this.invalidRef[0].$refs.input.tooltip;

        this.popupInvalidFields(msg);
        return false;
      } else {
        return this.sendDetails();
      }
    },

    /**
     * Gửi thay đổi
     * CREATED_BY: VMHOANG (18/07/2021)
     */
    async sendDetails() {
      let res;
      let returnValue = false;

      //Loại bỏ trường rỗng ra khỏi object
      Object.entries(this.employeeDetails).forEach(([key]) => {
        if (!this.employeeDetails[key] && this.employeeDetails[key] !== 0) {
          delete this.employeeDetails[key];
        }
      });

      this.isLoading = true;

      //Gửi dữ liệu
      try {
        switch (this.status.formType) {
          case "add":
          case "clone":
            res = await EmployeeService.create(this.employeeDetails);
            break;

          case "edit":
            res = await EmployeeService.edit(
              this.status.selectedId,
              this.employeeDetails
            );
            break;

          default:
            break;
        }

        //Nhận dữ liệu
        if (res?.status == 201) {
          this.$emit("success");
          this.notiChangeSucceed();
          this.$emit("status-change", false);
          returnValue = true;
        } else {
          this.popupServerResponse(res?.data?.UserMsg);
        }
      } catch (err) {
        console.log(err);
      }
      this.isLoading = false;
      return returnValue;
    },

    documentKeyup(e) {
      switch (e.code) {
        case "Escape":
          this.closeFormWithCheck();
          break;
        default:
          break;
      }
    },
  },

  unmounted() {
    // xóa event listeners khỏi document
    document.addEventListener("keyup", this.documentKeyup);
  },
};
</script>

<style lang="scss">
.details-modal {
  .m-modal-card {
    width: 900px !important;
    border-radius: 0px !important;

    .m-modal-header {
      .form-option {
        cursor: pointer;
      }

      .form-header-container {
        width: 100%;
        display: flex;
        justify-content: flex-start;
        align-items: center;

        padding: 20px 60px 20px 30px;

        & > span {
          font-size: 24px;
          font-weight: 700;
        }

        & > div {
          padding: 0 19.5px;
          display: flex;
          align-items: center;

          & > label {
            padding-left: 10px;
          }
        }
      }

      .form-header-options {
        position: absolute;
        top: 0;
        right: 0;
        display: flex;
        padding: 12px;
        gap: 10px;
        align-items: center;
      }
    }

    .m-modal-content {
      display: flex !important;
      flex-wrap: wrap;
      padding: 0 32px 20px 32px !important;
      justify-content: space-between;

      .label-field-input {
        margin-bottom: 12px;
        flex-basis: 100%;
      }

      .form-block-1 {
        flex-basis: calc(50% - 13px);
        display: flex;
        flex-wrap: wrap;
        justify-content: space-between;
        align-content: flex-start;
        box-sizing: border-box;

        & > .label-field-input:nth-child(1) {
          flex-basis: 35%;
        }

        & > .label-field-input:nth-child(2) {
          flex: 1;
          margin-left: 6px;
        }
      }

      .form-block-2 {
        flex-basis: calc(50% - 13px);
        display: flex;
        flex-wrap: wrap;
        justify-content: space-between;
        align-content: flex-start;
        box-sizing: border-box;

        .field-gender {
          display: flex;
          align-items: center;
          height: 32px;

          & > label {
            padding-left: 6px;
            padding-right: 20px;
          }
        }

        & > .label-field-input:nth-child(1) {
          flex-basis: 40%;
        }

        & > .label-field-input:nth-child(2) {
          flex: 1;
          margin-left: 16px;
        }

        & > .label-field-input:nth-child(3) {
          flex: 1;
        }

        & > .label-field-input:nth-child(4) {
          flex-basis: 40%;
          margin-left: 6px;
        }
      }

      .form-block-3 {
        flex-basis: 100%;
        gap: 6px;
        display: flex;
        flex-wrap: wrap;
        margin-top: 20px;

        & > .label-field-input:nth-child(n + 1) {
          flex-basis: 25%;
        }

        & > .label-field-input:first-child {
          flex-basis: 100%;
        }
      }
    }

    .m-modal-footer {
      display: flex;
      justify-content: space-between;
      align-items: center;

      & > div {
        display: flex;
        justify-content: flex-end;
        gap: 10px;
      }
    }
  }
}
</style>


