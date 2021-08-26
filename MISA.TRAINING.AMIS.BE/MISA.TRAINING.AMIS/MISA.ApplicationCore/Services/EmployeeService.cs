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

                //Tạo code mới
                if (maxCode == null || maxCode == "")
                {
                    //Trường hợp không có
                    newCode = "1";
                }
                else
                {
                    //lấy các chuỗi số từ mã cũ
                    var numArr = Regex.Split(maxCode, @"\D+");

                    //Nếu string kết thúc bằng số thì lấy phần tử cuối cùng của mảng numArr + 1
                    if (Char.IsDigit(maxCode[^1]))
                    {
                        codeNumber = Int32.Parse(numArr[numArr.Length - 1]) + 1;
                        codeNumberLength = codeNumber.ToString().Length;
                    }

                    //lấy prefix trước số
                    prefix = maxCode.Substring(0, maxCode.Length - codeNumberLength);

                    //Code mới
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

                //trim search string
                employeeFilter = employeeFilter?.Trim(' ') ?? "";

                if (pageNumber == null) pageNumber = defaultPageNumber;
                if (pageSize == null) pageSize = defaultPageSize;

                //cast trang sang int
                var iPageNumber = (int)pageNumber;
                var iPageSize = (int)pageSize;

                if (iPageNumber <= 0) iPageNumber = defaultPageNumber;
                if (iPageSize <= 0) iPageSize = defaultPageSize;

                //Lấy dữ liêu từ repository
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
