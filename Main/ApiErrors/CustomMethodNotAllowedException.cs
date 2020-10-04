using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Main.ApiErrors
{
    public class CustomMethodNotAllowedException : HttpStatusCodeException
    {
        public CustomMethodNotAllowedException(string msg) : base(HttpStatusCode.MethodNotAllowed, msg)
        {

        }
    }
}
