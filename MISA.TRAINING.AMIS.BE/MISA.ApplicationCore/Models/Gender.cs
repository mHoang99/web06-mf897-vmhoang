using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Models
{
    public class Gender : BaseModel
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        [PrimaryKey]
        [DisplayName("Khóa chính")]
        public Guid GenderId { get; set; }
        /// <summary>
        /// Mã vị trí
        /// </summary>
        [Required]
        [DisplayName("Mã giới tính")]
        public string GenderCode { get; set; }
        /// <summary>
        /// Tên vị trí
        /// </summary>
        [Required]
        [DisplayName("Tên giới tính")]
        public string GenderName { get; set; }
    }
}
