using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Exceptions;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Services
{
    /// <summary>
    /// Employee Service xử lý nghiệp vụ cho nhân viên
    /// </summary>
    /// CREATEDBY: VMHOANG (25/07/2021)
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region Properties
        /// <summary>
        /// Repository kết nối DB
        /// </summary>
        new readonly IEmployeeRepository _repository;
        #endregion

        #region Constructor
        public EmployeeService(IEmployeeRepository repository) : base(repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        async public Task<ServiceResult> GetNewEntityCode()
        {
            try
            {
                serviceResult.Data = await _repository.GetNewEntityCode();
                serviceResult.SuccessState = true;
                return serviceResult;
            }
            catch (Exception ex)
            {
                throw new ServiceException(
                    ex.Message,
                    UnexpectedErrorResponse(ex.Message)
                );
            }
        }

        async public Task<ServiceResult> Filter(string employeeFilter, Guid? departmentId, Guid? positionId, int? pageNumber, int? pageSize)
        {
            try
            {
                var defaultPageNumber = 1;
                var defaultPageSize = 5;

                if (pageNumber == null) pageNumber = defaultPageNumber;
                if (pageSize == null) pageSize = defaultPageSize;

                var iPageNumber = (int)pageNumber;
                var iPageSize = (int)pageSize;

                if (iPageNumber <= 0) iPageNumber = defaultPageNumber;
                if (iPageSize <= 0) iPageSize = defaultPageSize;

                serviceResult.Data = await _repository.Filter(
                    iPageNumber,
                    iPageSize,
                    employeeFilter,
                    departmentId,
                    positionId
                );

                serviceResult.SuccessState = true;
                serviceResult.MISACode = Enums.MISACode.IsValid;
                return serviceResult;
            }
            catch (Exception ex)
            {
                throw new ServiceException(
                    ex.Message,
                    UnexpectedErrorResponse(ex.Message)
                );
            }
        }
        #endregion
    }
}
