using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Models
{
    /// <summary>
    /// Vị trí
    /// </summary>
    /// CREATED_BY: vmhoang (22/07/2021)
    public class Position : BaseModel
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        [PrimaryKey]
        [DisplayName("Khóa chính")]
        public Guid PositionId { get; set; }
        /// <summary>
        /// Mã vị trí
        /// </summary>
        [Required]
        [DisplayName("Mã vị trí")]
        public string PositionCode { get; set; }
        /// <summary>
        /// Tên vị trí
        /// </summary>
        [Required]
        [DisplayName("Tên vị trí")]
        public string PositionName { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        [DisplayName("Mô tả")]
        public string Description { get; set; }
        /// <summary>
        /// Id của cha
        /// </summary>
        [DisplayName("Id của cha")]
        public Guid? ParentId { get; set; }
    }
}
