using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace GradingSystemBackend.Controllers
{
    [ApiController]
    [Route("api/v1/academiclevel")]
    public class AcademicLevelController : ControllerBase
    {
        private readonly IStrandManagementServices _strandManagementServices;
        private readonly IYearLevelManagementServices _yearLevelManagementServices;

        public AcademicLevelController(IStrandManagementServices strandManagementServices, IYearLevelManagementServices yearLevelManagementServices)
        {
            _strandManagementServices = strandManagementServices;
            _yearLevelManagementServices = yearLevelManagementServices;
        }

        [HttpGet("strands")]
        [ProducesResponseType<IEnumerable<StrandResponse>>(StatusCodes.Status200OK)]
        public IActionResult GetStrands()
        {
            var strands = _strandManagementServices.GetAllStrands();
            return Ok(strands);
        }

        [HttpGet("yearLevels")]
        [ProducesResponseType<IEnumerable<YearLevelResponse>>(StatusCodes.Status200OK)]
        public IActionResult GetYearLevelList()
        {
            var yearLevelList = _yearLevelManagementServices.GetAllYearLevel();
            return Ok(yearLevelList);
        }
    }
}
