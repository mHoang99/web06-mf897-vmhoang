using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Exceptions;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Services
{
    /// <summary>
    /// Employee Service xử lý nghiệp vụ cho nhân viên
    /// </summary>
    /// CREATEDBY: VMHOANG (25/07/2021)
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region Fields
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
                var maxCode = await _repository.GetMaxEntityCode();
                var prefix = "";
                var codeNumber = 0;
                var codeNumberLength = 0;
                var newCode = "";

                if (maxCode == null || maxCode == "")
                {
                    newCode = "1";
                }
                else
                {
                    var numArr = Regex.Split(maxCode, @"\D+");

                    if (Char.IsDigit(maxCode[^1]))
                    {
                        codeNumber = Int32.Parse(numArr[numArr.Length - 1]) + 1;
                        codeNumberLength = codeNumber.ToString().Length;
                    }

                    prefix = maxCode.Substring(0, maxCode.Length - codeNumberLength);

                    newCode = prefix + codeNumber;
                }

                serviceResult.Data = newCode;
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

        async public Task<ServiceResult> Filter(string employeeFilter, int? pageNumber, int? pageSize)
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
                    employeeFilter
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
