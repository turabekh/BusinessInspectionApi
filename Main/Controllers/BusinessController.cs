using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Interfaces;
using Main.ApiErrors;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DataTransferObjects.Read;
using Models.Parameters;
using Newtonsoft.Json;

[assembly:ApiConventionType(typeof(DefaultApiConventions))]
namespace Main.Controllers
{
    [Route("api/businesses")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryHub _repo;
        private IMapper _mapper;
        public BusinessController(ILoggerManager loggerManager, IRepositoryHub repo, IMapper mapper)
        {
            _logger = loggerManager;
            _repo = repo;
            _mapper = mapper;
        }


        [HttpGet("", Name = "GetAllBusinesses")]
        [EnableQuery()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetBusinesses([FromQuery] BusinessParameters businessParameters)
        {
            try
            {
                var businesses = await _repo.Business.GetAllBusinesses(businessParameters);
                _logger.LogInfo("Retrived All businesses from DB. Action: GetBusinesses");

                var metadata = new PaginationMetadata<Business>(businesses);

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                var businessesResult = _mapper.Map<IEnumerable<BusinessDto>>(businesses);
                return Ok(businessesResult);
            } 
            catch (Exception ex)
            {
                _logger.LogError($"Error happened in Action: GetBusinesses. Error: {ex.Message}");
                return new ObjectResult(new InternalServerError(ex));
            }

        }

        [HttpGet("{certificateNumber}", Name = "GetBusinessByBRCCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [EnableQuery()]
        public async Task<IActionResult> GetBusinessByBRCCode(string certificateNumber)
        {
            try
            {
                var business = await _repo.Business.GetBusinessByBRCCode(certificateNumber);
                if (business == null)
                {
                    _logger.LogError($"Business with BRCCode: {certificateNumber} not Found. Action: GetBusinessById");
                    var exception = new CustomNotFoundException($"Business with CertificateNumber: {certificateNumber} not found");
                    return NotFound(new NotFoundError(exception));
                }
                else
                {
                    _logger.LogInfo($"Retrieved Business with BRCCode: {business.BRCCode} from DB. GetBusinessByBRCCode Action");
                    var businessResult = _mapper.Map<BusinessDto>(business);
                    return Ok(businessResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error happened in Action: GetBusinessByBRCCode. Error: {ex.Message}");
                return new ObjectResult(new InternalServerError(ex));
            }
        }
    }
}
