using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Interfaces;
using Main.ApiErrors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


[assembly:ApiConventionType(typeof(DefaultApiConventions))]
namespace Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryHub _repo;
        public BusinessController(ILoggerManager loggerManager, IRepositoryHub repo)
        {
            _logger = loggerManager;
            _repo = repo;
        }

    }
}
