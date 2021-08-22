using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Models
{
    /// <summary>
    /// Nhân viên
    /// </summary>
    /// CREATED_BY: vmhoang (21/07/2021)
    public class Employee : BaseModel
    {
        #region Properties

        /// <summary>
        /// khóa chính
        /// </summary>
        [PrimaryKey]
        [DisplayName("Khóa chính")]
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// mã nhân viên
        /// </summary>
        [Required]
        [Unique]
        [MaxLength(20)]
        [DisplayName("Mã nhân viên")]
        public string EmployeeCode { get; set; }
        /// <summary>
        /// tên nhân viên
        /// </summary>
        [Required]
        [MaxLength(100)]
        [DisplayName("Tên đầy đủ của nhân viên")]
        public string EmployeeName { get; set; }


        /// <summary>
        /// Ngày sinh
        /// </summary>
        [DisplayName("Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// giới tính
        /// </summary>
        [DisplayName("Giới tính")]
        public int? Gender { get; set; }

        /// <summary>
        /// Khóa chính của bảng Department
        /// </summary>
        [Required]
        [DisplayName("Phòng ban")]
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// CMND
        /// </summary>
        [MaxLength(20)]
        [DisplayName("CMND")]
        public string IdentityNumber { get; set; }
        /// <summary>
        /// Ngày làm CMND/TCC
        /// </summary>
        [DisplayName("Ngày cấp CMND")]
        public DateTime? IdentityDate { get; set; }
        /// <summary>
        /// Nơi làm CMND/TCC
        /// </summary>
        [MaxLength(255)]
        [DisplayName("Nơi cấp CMTND")]
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Vị trí công việc
        /// </summary>
        [MaxLength(255)]
        [DisplayName("Vị trí")]
        public string EmployeePosition { get; set; }

        /// <summary>
        /// Tài khoản ngân hàng
        /// </summary>
        [MaxLength(255)]
        [DisplayName("Tài khoản ngân hàng")]
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        [MaxLength(255)]
        [DisplayName("Tên ngân hàng")]
        public string BankName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        [MaxLength(255)]
        [DisplayName("Chi nhánh ngân hàng")]
        public string BankBranchName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        [MaxLength(255)]
        [DisplayName("Vị trí ngân hàng")]
        public string BankProvinceName { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        [MaxLength(255)]
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [MaxLength(20)]
        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [MaxLength(20)]
        [DisplayName("Số điện thoại")]
        public string TelephoneNumber { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [DisplayName("Email")]
        public string Email { get; set; }


        #endregion
    }
}
