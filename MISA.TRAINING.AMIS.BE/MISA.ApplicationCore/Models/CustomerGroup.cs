using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Models
{
    /// <summary>
    /// Nhóm khách hàng
    /// </summary>
    /// CREATED_BY: vmhoang (22/07/2021)
    public class CustomerGroup : BaseModel
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        [PrimaryKey]
        [DisplayName("Khóa chính")]
        public Guid CustomerGroupId { get; set; }
        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        [Required]
        [DisplayName("Tên nhóm")]
        public string CustomerGroupName { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        [DisplayName("Mô tả")]
        public string Description { get; set; }
    }
}
