using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure
{
    /// <summary>
    /// Employee repository xử lý database cho nhân viên
    /// </summary>
    /// CREATEDBY: VMHOANG (27/07/2021)
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        #region Constructors
        public EmployeeRepository(IDBContext dBContext) : base(dBContext)
        {
        }
        #endregion

        #region Methods
        async public Task<Employee> GetEntityByCode(string code)
        {
            var parameters = new DynamicParameters();

            parameters.Add($"@{_tableName}Code", code, DbType.String);

            //Khởi tạo commandText
            var entity = await _dbConnection.QueryFirstOrDefaultAsync<Employee>(
                $"Proc_Get{_tableName}ByCode",
                parameters,
                commandType: CommandType.StoredProcedure
                );

            return entity;
        }

        async public Task<string> GetMaxEntityCode()
        {
            var newCode = await _dbConnection.QueryFirstOrDefaultAsync<string>(
                "Proc_GetNewEmployeeCode",
                commandType: CommandType.StoredProcedure
                );
            return newCode;
        }

        async public Task<object> Filter(int pageNumber, int pageSize, string employeeFilter)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PageSize", pageSize);
            parameters.Add("@PageIndex", pageNumber);
            parameters.Add("@EmployeeFilter", employeeFilter);
            parameters.Add("@TotalRecord", direction: ParameterDirection.Output);
            parameters.Add("@TotalPage", direction: ParameterDirection.Output);

            var result = await _dbConnection.QueryAsync<object>("Proc_GetEmployeesFilterPaging", parameters, commandType: CommandType.StoredProcedure);

            int totalPage = parameters.Get<int>("@TotalPage");
            int totalRecord = parameters.Get<int>("@TotalRecord");

            return new {
                Data = result,
                TotalRecord = totalRecord,
                TotalPage = totalPage
            };

        }
        #endregion
    }
}
