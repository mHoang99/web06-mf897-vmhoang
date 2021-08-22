﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.ApplicationCore.Models;
using MISA.ApplicationCore.Interfaces;

namespace MISA.CukCuk.API.Apis
{
    public class DepartmentController : BaseApiController<Department>
    {
        public DepartmentController(IBaseService<Department> service) : base(service)
        {
        }
    }
}
