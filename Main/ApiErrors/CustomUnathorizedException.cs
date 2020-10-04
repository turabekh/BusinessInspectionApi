using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Main.ApiErrors
{
    public class CustomUnathorizedException : HttpStatusCodeException
    {
        public CustomUnathorizedException(string msg) : base(HttpStatusCode.Unauthorized, msg)
        {

        }
    }
}
