using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace GradingSystemBackend.Controllers
{
    [ApiController]
    [Route("api/v1/subjects")]
    public class SubjectManagementController : ControllerBase
    {
        private readonly ISubjectManagementServices _subjectManagementServices;

        public SubjectManagementController(ISubjectManagementServices subjectManagementServices) 
        { 
            _subjectManagementServices = subjectManagementServices;
        }

        [HttpPost]
        [ProducesResponseType<DefaultResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddSubject(SubjectDTO newSubject)
        {
            var response = await _subjectManagementServices.AddSubject(newSubject);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType<DefaultResponse>(StatusCodes.Status200OK)]
        public IActionResult UpdateSubject(Guid id, SubjectDTO subject)
        {
            var response = _subjectManagementServices.UpdateSubject(id, subject);
            return Ok(response);
        }

        [HttpGet("all")]
        [ProducesResponseType<IEnumerable<SubjectResponse>>(StatusCodes.Status200OK)]
        public IActionResult GetSubjects()
        {
            var response = _subjectManagementServices.GetAllSubjects();
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType<IEnumerable<SubjectResponse>>(StatusCodes.Status200OK)]
        public IActionResult GetSubjects([FromQuery] FilterDTO filterDTO) 
        {
            var response = _subjectManagementServices.GetAllSubjects(filterDTO);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType<SubjectResponse>(StatusCodes.Status200OK)]
        public IActionResult GetSubject(Guid id)
        {
            var response = _subjectManagementServices.GetSubject(id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType<DefaultResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<DefaultExceptionResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSubject(Guid id) 
        {
            var response = await _subjectManagementServices.DeleteSubject(id);
            return Ok(response);
        }
    }
}
