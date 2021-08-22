using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Models
{
    public class WorkStatus : BaseModel
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        [PrimaryKey]
        [DisplayName("Khóa chính")]
        public Guid WorkStatusId { get; set; }
        /// <summary>
        /// Mã vị trí
        /// </summary>
        [Required]
        [DisplayName("Mã trạng thái công việc")]
        public string WorkStatusCode { get; set; }
        /// <summary>
        /// Tên vị trí
        /// </summary>
        [Required]
        [DisplayName("Tên trạng thái công việc")]
        public string WorkStatusName { get; set; }
    }
}
