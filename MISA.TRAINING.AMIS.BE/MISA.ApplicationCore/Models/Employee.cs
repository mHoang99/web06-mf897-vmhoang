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
        [DisplayName("Mã nhân viên")]
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Tên khách hàng
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Họ khách hàng
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// tên nhân viên
        /// </summary>
        [Required]
        [MaxLength(20)]
        [DisplayName("Tên đầy đủ của nhân viên")]
        public string FullName { get; set; }

        /// <summary>
        /// giới tính
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Required]
        [Unique]
        [PhoneNumber]
        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [Unique]
        [Email]
        [DisplayName("Email")]
        public string Email { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        /// <summary>
        /// CMND/TCC
        /// </summary>
        [Required]
        [Unique]
        [DisplayName("CMND/TCC")]
        public string IdentityNumber { get; set; }
        /// <summary>
        /// Ngày làm CMND/TCC
        /// </summary>
        [DisplayName("Ngày cấp CMND/TCC")]
        public DateTime? IdentityDate { get; set; }
        /// <summary>
        /// Nơi làm CMND/TCC
        /// </summary>
        [DisplayName("Nơi cấp CMTND/TCC")]
        public string IdentityPlace { get; set; }
        /// <summary>
        /// Ngày gia nhập công ty
        /// </summary
        [DisplayName("Ngày gia nhập")]
        public DateTime? JoinDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("")]
        public int? MartialStatus { get; set; }
        /// <summary>
        /// Trình độ học vấn
        /// </summary>
        [DisplayName("Trình độ học vấn")]
        public int? EducationalBackground { get; set; }
        /// <summary>
        /// Khóa chính của bảng qualification
        /// </summary>
        [DisplayName("Chứng chỉ")]
        public Guid? QualificationId { get; set; }
        /// <summary>
        /// Khóa chính của bảng Department
        /// </summary>
        [DisplayName("Phòng ban")]
        public Guid? DepartmentId { get; set; }
        /// <summary>
        /// Khóa chính của bảng Position
        /// </summary>
        [DisplayName("Vị trí")]
        public Guid? PositionId { get; set; }
        /// <summary>
        /// Tình trạng công việc
        /// </summary>
        [DisplayName("Tình trạng công việc")]
        public int WorkStatus { get; set; }
        /// <summary>
        /// Mã số thuế cá nhân
        /// </summary>
        [DisplayName("Mã số thuế cá nhân")]
        public string PersonalTaxCode { get; set; }
        /// <summary>
        /// Lương
        /// </summary>
        [DisplayName("Lương")]
        public double? Salary { get; set; }
        #endregion
    }
}
