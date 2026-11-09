using CampusPlacementManagement.DTOs.Student;
using CampusPlacementManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] StudentRegisterDto dto)
        {
            var success = await _studentService.RegisterStudentAsync(dto);
            if (!success) return BadRequest(new { message = "Registration failed. Ensure the college is approved." });
            return Ok(new { message = "Student registered successfully. Pending approval." });
        }

        [HttpGet("pending")]
        [Authorize(Roles = "SuperAdmin,PlacementOfficer")]
        public async Task<IActionResult> GetPending() => Ok(await _studentService.GetPendingStudentsAsync());

        [HttpPut("{id}/approve")]
        [Authorize(Roles = "SuperAdmin,PlacementOfficer")]
        public async Task<IActionResult> Approve(int id)
        {
            var success = await _studentService.ApproveStudentAsync(id);
            if (!success) return NotFound(new { message = "Student not found." });
            return Ok(new { message = "Student approved successfully." });
        }

        [HttpPut("{id}/reject")]
        [Authorize(Roles = "SuperAdmin,PlacementOfficer")]
        public async Task<IActionResult> Reject(int id)
        {
            var success = await _studentService.RejectStudentAsync(id);
            if (!success) return NotFound(new { message = "Student not found." });
            return Ok(new { message = "Student rejected." });
        }
    }
}