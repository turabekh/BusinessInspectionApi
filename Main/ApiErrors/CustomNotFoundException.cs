using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Main.ApiErrors
{
    public class CustomNotFoundException : HttpStatusCodeException
    {
        public CustomNotFoundException(string msg) : base(HttpStatusCode.NotFound, msg)
        {

        }
    }
}
