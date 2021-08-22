using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Models;

namespace MISA.ApplicationCore
{
    /// <summary>
    /// Employee Service xử lý nghiệp vụ cho khách hàng
    /// </summary>
    /// CREATEDBY: VMHOANG (25/07/2021)
    public class CustomerService : BaseService<Customer>, IBaseService
    {
        #region Properties
        /// <summary>
        /// repository kết nối tới DB
        /// </summary>
        new ICustomerRepository _repository;
        #endregion  

        #region Constructor
        public CustomerService(ICustomerRepository repository) : base(repository)
        {
            _repository = repository;
        }
        #endregion
    }
}
