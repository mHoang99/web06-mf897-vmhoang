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
    [Route("api/v1/[controller]es")]
    public class WorkStatusController : BaseApiController<WorkStatus>
    {
        public WorkStatusController(IBaseService<WorkStatus> service) : base(service)
        {
        }
    }
}

