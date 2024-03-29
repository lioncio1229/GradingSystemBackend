﻿using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Repositories;
using GradingSystemBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GradingSystemBackend.Controllers
{
    [ApiController]
    [Route("api/v1/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;

        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType<DefaultResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddStudent(StudentDTO studentDTO)
        {
            var response = await _studentServices.AddStudent(studentDTO);
            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        [ProducesResponseType<DefaultResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<DefaultExceptionResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateStudent(Guid id, StudentDTO studentDTO)
        {
            var response = await _studentServices.UpdateStudent(id, studentDTO);
            return Ok(response);
        }

        [HttpGet("all")]
        [ProducesResponseType<IEnumerator<StudentResponse>>(StatusCodes.Status200OK)]
        public IActionResult GetStudents() {  return Ok(_studentServices.GetStudents()); }

        [HttpGet]
        [ProducesResponseType<IEnumerator<StudentResponse>>(StatusCodes.Status200OK)]
        public IActionResult GetStudents([FromQuery] FilterDTO filterDTO) { return Ok(_studentServices.GetStudents(filterDTO)); }

        [HttpGet("{id}")]
        [ProducesResponseType<StudentResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<DefaultExceptionResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStudent(Guid id)
        {
            var response = await _studentServices.GetStudent(id);
            return Ok(response);
        }

        [Authorize(Roles = "admin")]
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
