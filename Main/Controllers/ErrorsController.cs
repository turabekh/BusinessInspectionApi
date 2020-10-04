using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Main.ApiErrors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    [Route("api/error")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error; 
            var code = 500; 

            if (exception is CustomNotFoundException) code = 404; 
            else if (exception is CustomUnathorizedException) code = 401; 
            else if (exception is CustomBadRequestException) code = 400; 
            else if (exception is CustomMethodNotAllowedException) code = 405;

            Response.StatusCode = code; 
            var error = new ApiError(exception, code);
            return new ObjectResult(error);
            
        }
    }
}
