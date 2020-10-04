using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.ApiErrors
{
    public class UnAuthorizedError : ApiError
    {
        public UnAuthorizedError(Exception ex)
            :base(ex, 401)
        {

        }
    }
}
