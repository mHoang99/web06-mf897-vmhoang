using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.API.Apis
{
    public class GenderController : BaseApiController<Gender>
    {
        public GenderController(IBaseService<Gender> service) : base(service)
        {
        }
    }
}
