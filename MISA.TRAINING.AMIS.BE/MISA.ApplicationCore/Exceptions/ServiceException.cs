using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceResult ServiceResult { get; }

        public ServiceException(string msg, ServiceResult res) : base(msg)
        {
            this.ServiceResult = res;
        }
    }
}
