using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.ApiErrors
{
    public class BadRequestError : ApiError
    {
        public BadRequestError(Exception ex)
            : base(ex, 400)
        {

        }
    }
}
