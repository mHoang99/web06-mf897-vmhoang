using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Models;
using MISA.ApplicationCore.Entities;
using MISA.Infrastructure.Database;

namespace MISA.CukCuk.API.Apis
{
    /// <summary>
    /// Api controller cho nhân viên
    /// </summary>
    /// CREATED_BY: vmhoang (22/07/2021)
    public class CustomerController : BaseApiController<Customer>
    {
        new IBaseService _service;
        public CustomerController(IBaseService service):base(service)
        {
            _service = service;
        }
    }
}
