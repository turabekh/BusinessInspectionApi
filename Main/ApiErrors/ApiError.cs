using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.ApiErrors
{
    public class ApiError
    {
        public string Type { get; private set; }
        public string Message { get; private set; }
        public string StackTrace { get; private set; }
        public int StatusCode { get; private set; }

        public ApiError(Exception ex, int statusCode)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;
            StackTrace = ex.ToString();
            StatusCode = statusCode;
        }
    }
}
