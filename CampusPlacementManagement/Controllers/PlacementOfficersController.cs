using CampusPlacementManagement.DTOs.PlacementOfficer;
using CampusPlacementManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Controllers
{
    [Route("api/placement-officers")]
    [ApiController]
    public class PlacementOfficersController : ControllerBase
    {
        private readonly IPlacementOfficerService _officerService;

        public PlacementOfficersController(IPlacementOfficerService officerService)
        {
            _officerService = officerService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] PlacementOfficerRegisterDto dto)
        {
            var success = await _officerService.RegisterOfficerAsync(dto);
            if (!success) return BadRequest(new { message = "Registration failed. Ensure the college is approved." });
            return Ok(new { message = "Placement officer registered successfully. Pending SuperAdmin approval." });
        }

        [HttpGet("pending")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> GetPending() => Ok(await _officerService.GetPendingOfficersAsync());

        [HttpPut("{id}/approve")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Approve(int id)
        {
            var adminUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var success = await _officerService.ApproveOfficerAsync(id, adminUserId);
            if (!success) return NotFound(new { message = "Placement officer not found." });
            return Ok(new { message = "Placement officer approved successfully." });
        }

        [HttpPut("{id}/reject")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Reject(int id)
        {
            var success = await _officerService.RejectOfficerAsync(id);
            if (!success) return NotFound(new { message = "Placement officer not found." });
            return Ok(new { message = "Placement officer rejected." });
        }
    }
}