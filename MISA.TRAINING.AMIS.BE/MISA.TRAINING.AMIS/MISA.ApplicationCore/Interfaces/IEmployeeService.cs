using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface cho Employee Service
    /// </summary>
    /// CREATEDBY: VMHOANG (25/07/2021)
    public interface IEmployeeService : IBaseService<Employee>
    {
        #region Methods
        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        Task<ServiceResult> GetNewEntityCode();

        /// <summary>
        /// Hàm lọc nhân viên
        /// </summary>
        /// <param name="pageNumber">Số trang</param>
        /// <param name="pageSize">Kích thước trang</param>
        /// <param name="employeeFilter">search string</param>
        /// <returns>Thông tin trả về</returns>
        Task<ServiceResult> Filter(string employeeFilter, int? pageNumber, int? pageSize);
        #endregion
    }
}
