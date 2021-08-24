using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using MISA.ApplicationCore.Models;
using MISA.ApplicationCore.Services;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Helpers;
using MISA.ApplicationCore.Exceptions;

namespace MISA.AMIS.API.Apis
{
    /// <summary>
    /// Api controller cho nhân viên
    /// </summary>
    /// CREATED_BY: vmhoang (21/07/2021)
    public class EmployeeController : BaseApiController<Employee>
    {
        #region Fields
        new IEmployeeService _service;

        #endregion

        #region Constructors
        public EmployeeController(IEmployeeService service) : base(service)
        {
            _service = service;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy nhân viên theo filter
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="EmployeeFilter"></param>
        /// <returns></returns>
        [HttpGet("FilterPaging")]
        public async Task<IActionResult> FiterAsync(
                [FromQuery] int? pageNumber,
                [FromQuery] int? pageSize,
                [FromQuery] string EmployeeFilter

            )
        {
            var result = await _service.Filter(EmployeeFilter, pageNumber, pageSize);

            if (result.SuccessState)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.ConvertToApiReturn());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("NewEmployeeCode")]
        public async Task<IActionResult> GetNewEmployeeCodeAsync()
        {
            var result = await _service.GetNewEntityCode();

            if (result.SuccessState)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.ConvertToApiReturn());
            }
        }
        #endregion
    }


}
