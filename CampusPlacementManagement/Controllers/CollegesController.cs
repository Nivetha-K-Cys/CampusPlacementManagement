using CampusPlacementManagement.DTOs.College;
using CampusPlacementManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Controllers
{
    [Route("api/colleges")]
    [ApiController]
    public class CollegesController : ControllerBase
    {
        private readonly ICollegeService _collegeService;

        public CollegesController(ICollegeService collegeService)
        {
            _collegeService = collegeService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CollegeRegisterDto dto)
        {
            var college = await _collegeService.RegisterCollegeAsync(dto);
            return Ok(new { message = "College registration submitted successfully. Pending SuperAdmin approval.", college });
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> GetAll() => Ok(await _collegeService.GetAllCollegesAsync());

        [HttpGet("pending")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> GetPending() => Ok(await _collegeService.GetPendingCollegesAsync());

        [HttpPut("{id}/approve")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Approve(int id)
        {
            var success = await _collegeService.ApproveCollegeAsync(id);
            if (!success) return NotFound(new { message = "College not found." });
            return Ok(new { message = "College approved successfully." });
        }

        [HttpPut("{id}/reject")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Reject(int id)
        {
            var success = await _collegeService.RejectCollegeAsync(id);
            if (!success) return NotFound(new { message = "College not found." });
            return Ok(new { message = "College rejected." });
        }

        [HttpPut("{id}/suspend")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Suspend(int id)
        {
            var success = await _collegeService.SuspendCollegeAsync(id);
            if (!success) return NotFound(new { message = "College not found." });
            return Ok(new { message = "College suspended." });
        }
    }
}