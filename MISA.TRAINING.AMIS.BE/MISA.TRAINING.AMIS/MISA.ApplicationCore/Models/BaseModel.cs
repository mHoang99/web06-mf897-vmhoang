﻿using MISA.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Models
{
    /// <summary>
    /// Class Attribute cho trường bắt buộc
    /// </summary>
    /// CREATEDBY: VMHOANG (10/08/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {

    }

    /// <summary>
    /// Class Attribute cho trường không được phép trùng
    /// </summary>
    /// CREATEDBY: VMHOANG (10/08/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class Unique : Attribute
    {

    }

    /// <summary>
    /// Class Attribute cho trường khóa chính
    /// </summary>
    /// CREATEDBY: VMHOANG (10/08/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {

    }

    /// <summary>
    /// Class Attribute cho trường là email
    /// </summary>
    /// CREATEDBY: VMHOANG (10/08/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class Email : Attribute
    {
    }

    /// <summary>
    /// Class Attribute cho trường số điện thoại
    /// </summary>
    /// CREATEDBY: VMHOANG (10/08/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class PhoneNumber : Attribute
    {

    }

    /// <summary>
    /// Class Attribute cho trường có độ dài tối đa
    /// </summary>
    /// CREATEDBY: VMHOANG (10/08/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength: Attribute
    {
        #region Properties
        public int Value { get; set; }
        #endregion

        #region Constructor
        public MaxLength(int maxLength = 20)
        {
            this.Value = maxLength;
        }
        #endregion
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
