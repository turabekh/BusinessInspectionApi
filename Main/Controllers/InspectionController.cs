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
    [Route("api/inspections")]
    [ApiController]
    public class InspectionController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryHub _repo;

        public InspectionController(ILoggerManager loggerManager, IRepositoryHub repo)
        {
            _logger = loggerManager;
            _repo = repo;
        }
    }
}
