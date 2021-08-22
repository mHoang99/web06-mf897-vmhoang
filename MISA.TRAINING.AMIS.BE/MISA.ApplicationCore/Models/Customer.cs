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
     /// CREATED_BY: vmhoang (22/07/2021)
    public class Customer : BaseModel
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        [PrimaryKey]
        [DisplayName("Khóa chính")]
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [Required]
        [DisplayName("Mã khách hàng")]
        public string CustomerCode { get; set; }
        /// <summary>
        /// Tên khách hàng
        /// </summary>
        [DisplayName("Tên khách hàng")]
        public string FirstName { get; set; }
        /// <summary>
        /// Họ khách hàng
        /// </summary>
        [DisplayName("Họ khách hàng")]
        public string LastName { get; set; }
        /// <summary>
        /// Tên đầy đủ của khách hàng
        /// </summary>
        [Required]
        [DisplayName("Tên đầy đủ của khách hàng")]
        public string FullName { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        [DisplayName("Giới tính")]
        public int? Gender { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        [DisplayName("Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [DisplayName("Email")]
        public string Email { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Required]
        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Id nhóm khách hàng
        /// </summary>
        [DisplayName("Id nhóm khách hàng")]
        public Guid? CustomerGroupId { get; set; }
        /// <summary>
        /// Tiền debit
        /// </summary>
        [DisplayName("Tiền rút")]
        public double? DebitAmount { get; set; }
        /// <summary>
        /// Mã thẻ thành viên
        /// </summary>
        [DisplayName("Mã thẻ thành viên")]
        public string MemberCardCode { get; set; }
        /// <summary>
        /// Tên công ty
        /// </summary>
        [DisplayName("Tên công ty")]
        public string CompanyName { get; set; }
        /// <summary>
        /// Mã số thuế
        /// </summary>
        [DisplayName("Mã số thuế")]
        public string CompanyTaxCode { get; set; }
        /// <summary>
        /// Theo dõi
        /// </summary>
        [DisplayName("Theo dõi")]
        public bool? IsStopFollow { get; set; }
    }
}