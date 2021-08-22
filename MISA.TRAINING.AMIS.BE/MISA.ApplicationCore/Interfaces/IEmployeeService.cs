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
        /// <param name="departmentId">Id của phòng ban</param>
        /// <param name="positionId">Id của vị trí</param>
        /// <returns></returns>
        Task<ServiceResult> Filter(string employeeFilter, Guid? departmentId, Guid? positionId, int? pageNumber, int? pageSize);
    }
}
