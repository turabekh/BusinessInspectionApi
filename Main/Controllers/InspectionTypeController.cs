using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionTypeController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryHub _repo;
        public InspectionTypeController(ILoggerManager loggerManager, IRepositoryHub repo)
        {
            _logger = loggerManager;
            _repo = repo;
        }

    }
}
