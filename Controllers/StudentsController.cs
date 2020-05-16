using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using APBD09.DTOs;
using APBD09.Models;
using APBD09.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD09.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentDbService _service;
        public StudentsController(IStudentDbService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_service.GetStudents());
        }
        [HttpPut]
        public IActionResult ModifyStudent(Student student)
        {
            _service.ModifyStudent(student);
            return Ok();
        }
        [HttpDelete("{index}")]
        public IActionResult DeleteStudent(string index)
        {
            _service.DeleteStudent(index);
            return Ok();
        }
        [HttpPost]
        public IActionResult EnrollStudent(EnrollRequest student)
        {
            _service.EnrollStudent(student);
            return Ok();
        }
    }
}