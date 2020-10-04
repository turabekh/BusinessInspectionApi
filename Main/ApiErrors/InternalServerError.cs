using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Main.ApiErrors
{
    public class InternalServerError : ApiError
    {
        public InternalServerError(Exception ex) 
            : base(ex, 500)
        {

        }
    }
}
