using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GradingSystemBackend.Controllers
{
    [ApiController]
    [Route("api/v1/lectures")]
    public class LectureController : ControllerBase
    {
        private readonly ILectureManagementServices _lectureServices;

        public LectureController(ILectureManagementServices lectureServices)
        {
            _lectureServices = lectureServices;
        }

        [HttpGet("all")]
        [ProducesResponseType<IEnumerable<LectureResponse>>(StatusCodes.Status200OK)]
        public IActionResult GetAllLecture()
        {
            return Ok(_lectureServices.GetAllLecture());
        }

        [HttpGet]
        [ProducesResponseType<IEnumerable<LectureResponse>>(StatusCodes.Status200OK)]
        public IActionResult GetAllLecture([FromQuery] FilterDTO filterDTO)
        {
            return Ok(_lectureServices.GetAllLecture(filterDTO));
        }

        [HttpGet("{id}")]
        [ProducesResponseType<LectureResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<DefaultExceptionResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLecture(Guid id)
        {
            var response = await _lectureServices.GetLecture(id);
            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType<DefaultResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddLecture(LectureDTO lectureDTO)
        {
            var response = await _lectureServices.AddLecture(lectureDTO);
            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        [ProducesResponseType<DefaultResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<DefaultExceptionResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateLecture(Guid id, LectureDTO lectureDTO)
        {
            var response = await _lectureServices.UpdateLecture(id, lectureDTO);
            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType<DefaultResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<DefaultExceptionResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteLecture(Guid id)
        {
            var response = await _lectureServices.DeleteLecture(id);
            return Ok(response);
        }
    }
}
