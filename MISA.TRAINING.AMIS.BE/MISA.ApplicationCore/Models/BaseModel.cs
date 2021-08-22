using MISA.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {

    }


    [AttributeUsage(AttributeTargets.Property)]
    public class Unique : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Email : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class PhoneNumber : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength: Attribute
    {
        public int Value { get; set; }
        public MaxLength(int maxLength = 20)
        {
            this.Value = maxLength;
        }
    }

    public class BaseModel
    {
        #region Properties
        public EntityState EntityState { get; set; } = EntityState.ADD;
        /// <summary>
        /// Ngày tạo
        /// </summary>
        [DisplayName("Ngày tạo")]
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        [DisplayName("Người tạo")]
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày thay đổi gần nhất
        /// </summary>
        [DisplayName("Ngày thay đổi gần nhất")]
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người thay đổi gần nhất
        /// </summary>
        [DisplayName("Người thay đổi")]
        public string ModifiedBy { get; set; }
        #endregion
    }
}
