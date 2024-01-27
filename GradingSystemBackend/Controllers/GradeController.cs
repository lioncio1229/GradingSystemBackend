using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Exceptions;
using GradingSystemBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace GradingSystemBackend.Controllers
{
    [ApiController]
    [Route("api/v1/grades")]
    public class GradeController : ControllerBase
    {
        private readonly IGradeManagementServices _gradeManagementServices;
        public GradeController(IGradeManagementServices gradeManagementServices)
        {
            _gradeManagementServices = gradeManagementServices;
        }

        [HttpPut("{id}")]
        [ProducesResponseType<DefaultResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<DefaultExceptionResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateGrade(Guid id, GradesUpdateDTO gradesUpdateDTO)
        {
            var response = await _gradeManagementServices.UpdateGrades(id, gradesUpdateDTO);
            return Ok(response);
        }

        [HttpGet("subject/{subjectId}")]
        [ProducesResponseType<IEnumerable<StudentGradeResponse>>(StatusCodes.Status200OK)]
        public IActionResult GetStudentGrades(Guid subjectId)
        {
            var response = _gradeManagementServices.GetStudentGrades(subjectId);
            return Ok(response);
        }
    }
}
