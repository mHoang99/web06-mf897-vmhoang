using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface cho Employee Repository
    /// </summary>
    /// CREATEDBY: VMHOANG (27/07/2021)
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        #region Methods
        /// <summary>
        /// Lấy nhân viên theo mã code
        /// </summary>
        /// <param name="code">EmployeeCode</param>
        /// <returns>Nhân viên tìm được | null</returns>
        public Task<Employee> GetEntityByCode(string code);
        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        Task<string> GetMaxEntityCode();
        /// <summary>
        /// Lọc nhân viên
        /// </summary>
        /// <param name="pageNumber">Số trang</param>
        /// <param name="pageSize">Kích thước trang</param>
        /// <param name="employeeFilter">Từ khóa</param>
        /// <param name="departmentId">Id phòng ban</param>
        /// <param name="positionId">Id vị trí</param>
        /// <returns>Nhân viên tìm được, tổng số bản ghi, tổng số trang</returns>
        Task<object> Filter(int pageNumber, int pageSize, string employeeFilter, Guid? departmentId, Guid? positionId);
        #endregion
    }
}
