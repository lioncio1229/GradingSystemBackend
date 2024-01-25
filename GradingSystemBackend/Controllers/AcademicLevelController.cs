using GradingSystemBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace GradingSystemBackend.Controllers
{
    [ApiController]
    [Route("api/v1/academiclevel")]
    public class AcademicLevelController : ControllerBase
    {
        private readonly IStrandManagementServices _strandManagementServices;
        public AcademicLevelController(IStrandManagementServices strandManagementServices)
        {
            _strandManagementServices = strandManagementServices;
        }

        [HttpGet("strands")]
        public IActionResult GetStrands()
        {
            var strands = _strandManagementServices.GetAllStrands();
            return Ok(strands);
        }
    }
}
