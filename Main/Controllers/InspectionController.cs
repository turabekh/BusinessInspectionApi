using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Interfaces;
using Main.ApiErrors;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DataTransferObjects.Read;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace Main.Controllers
{
    [Route("api/inspections")]
    [ApiController]
    public class InspectionController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryHub _repo;
        private IMapper _mapper;

        public InspectionController(ILoggerManager loggerManager, IRepositoryHub repo, IMapper mapper)
        {
            _logger = loggerManager;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("", Name = "GetAllInspections")]
        [EnableQuery()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAllInspections()
        {
            try
            {
                var inspections = await _repo.Inspection.GetAllInspections();
                _logger.LogInfo("Retrived All inspections from DB. Action: GetAllInspections");

                var inspectionsResult = _mapper.Map<IEnumerable<InspectionDto>>(inspections);
                return Ok(inspectionsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error happened in Action: GetAllInspections. Error: {ex.Message}");
                return new ObjectResult(new InternalServerError(ex));
            }

        }



        [HttpGet("{id}", Name = "GetInspectionById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [EnableQuery()]
        public async Task<IActionResult> GetInspectionById(int id)
        {
            try
            {
                var inspection = await _repo.Inspection.GetInspectionById(id);
                if (inspection == null)
                {
                    _logger.LogError($"Inspection with ID: {id} not Found. Action: GetInspectionById");
                    var exception = new CustomNotFoundException($"Inspection with ID: {id} not found");
                    return NotFound(new NotFoundError(exception));
                }
                else
                {
                    _logger.LogInfo($"Retrieved Inspection with ID: {inspection.Id} from DB. GetInspectionById Action");
                    var inspectionResult = _mapper.Map<InspectionDto>(inspection);
                    return Ok(inspectionResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error happened in Action: GetInspectionById. Error: {ex.Message}");
                return new ObjectResult(new InternalServerError(ex));
            }
        }
    }
}
