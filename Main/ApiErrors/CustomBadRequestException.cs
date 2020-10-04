using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Main.ApiErrors
{
    public class CustomBadRequestException : HttpStatusCodeException
    {
        public CustomBadRequestException(string msg) : base(HttpStatusCode.BadRequest, msg)
        {

        }
    }
}
