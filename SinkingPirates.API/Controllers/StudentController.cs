using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SinkingPirates.API.Manager.Student;
using SinkingPirates.API.Models;

namespace SinkingPirates.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentManager _studentManager;

        public StudentController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentManager.GetAllStudents();
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDto studentDto)
        {
            await _studentManager.CreateNewStudent(studentDto);
            return StatusCode(201);
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudent([FromQuery] int studentId)
        {
            try
            {
               var response = await _studentManager.DeleteStudent(studentId);
                if (response == 0) return BadRequest("Unable to delete student");
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest($"Unable to delete student: {ex.Message}");
            }
          
        }
    }
}
