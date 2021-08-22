using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Models
{
    /// <summary>
    /// Phòng ban
    /// </summary>
    /// CREATED_BY: vmhoang (22/07/2021)
    public class Department : BaseModel
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        [PrimaryKey]
        [DisplayName("Khóa chính")]
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Mã phòng ban
        /// </summary>
        [Required]
        [DisplayName("Mã phòng ban")]
        public string DepartmentCode { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        [Required]
        [DisplayName("Tên phòng ban")]
        public string DepartmentName { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        [DisplayName("Mô tả")]
        public string Description { get; set; }
    }
}
