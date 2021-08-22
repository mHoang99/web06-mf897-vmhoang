using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using MISA.ApplicationCore.Models;
using MISA.Infrastructure.Database;
using MISA.ApplicationCore.Interfaces;

namespace MISA.CukCuk.API.Apis
{
    public class CustomerGroupController : BaseApiController<CustomerGroup>
    {
        public CustomerGroupController (IBaseService<CustomerGroup> service) : base(service)
        {
        }
    }
}
