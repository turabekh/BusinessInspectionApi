using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.ApiErrors
{
    public class NotFoundError : ApiError 
    {
        public NotFoundError(Exception ex) 
            : base(ex, 404)
        {

        }
    }
}
