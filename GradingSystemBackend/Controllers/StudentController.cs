using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Repositories;
using GradingSystemBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace GradingSystemBackend.Controllers
{
    [ApiController]
    [Route("api/v1/student")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;

        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        [HttpPost]
        [ProducesResponseType<DefaultResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddStudent(StudentDTO studentDTO)
        {
            var response = await _studentServices.AddStudent(studentDTO);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType<DefaultResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<DefaultExceptionResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateStudent(Guid id, StudentDTO studentDTO)
        {
            var response = await _studentServices.UpdateStudent(id, studentDTO);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType<IEnumerator<StudentResponse>>(StatusCodes.Status200OK)]
        public IActionResult GetStudents() {  return Ok(_studentServices.GetStudents()); }

        [HttpGet("{id}")]
        [ProducesResponseType<StudentResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<DefaultExceptionResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStudent(Guid id)
        {
            var response = await _studentServices.GetStudent(id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType<DefaultResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<DefaultExceptionResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var response = await _studentServices.DeleteStudent(id);
            return Ok(response);
        }
    }
}
