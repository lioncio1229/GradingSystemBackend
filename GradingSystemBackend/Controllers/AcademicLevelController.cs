using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Repositories;
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
        private readonly ISemesterManagementServices _semesterManagementServices;

        public AcademicLevelController(IStrandManagementServices strandManagementServices,
            IYearLevelManagementServices yearLevelManagementServices, 
            ISemesterManagementServices semesterManagementServices)
        {
            _strandManagementServices = strandManagementServices;
            _yearLevelManagementServices = yearLevelManagementServices;
            _semesterManagementServices = semesterManagementServices;
        }

        [HttpGet("strands")]
        [ProducesResponseType<IEnumerable<StrandResponse>>(StatusCodes.Status200OK)]
        public IActionResult GetStrands()
        {
            var strands = _strandManagementServices.GetAllStrands();
            return Ok(strands);
        }

        [HttpGet("yearlevels")]
        [ProducesResponseType<IEnumerable<YearLevelResponse>>(StatusCodes.Status200OK)]
        public IActionResult GetYearLevelList()
        {
            var yearLevelList = _yearLevelManagementServices.GetAllYearLevel();
            return Ok(yearLevelList);
        }

        [HttpGet("semesters")]
        [ProducesResponseType<IEnumerable<SemesterResponse>>(StatusCodes.Status200OK)]
        public IActionResult GetSemesters() 
        {
            var semesters = _semesterManagementServices.GetAllSemester();
            return Ok(semesters);
        }
    }
}
