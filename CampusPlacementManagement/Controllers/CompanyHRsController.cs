using CampusPlacementManagement.DTOs.CompanyHR;
using CampusPlacementManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Controllers
{
    [Route("api/company-hrs")]
    [ApiController]
    public class CompanyHRsController : ControllerBase
    {
        private readonly ICompanyHRService _hrService;

        public CompanyHRsController(ICompanyHRService hrService)
        {
            _hrService = hrService;
        }

        [HttpGet("pending")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> GetPendingHRs() =>
            Ok(await _hrService.GetPendingHRsAsync());

        [HttpPut("{id}/approve")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> ApproveHR(int id)
        {
            var adminUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(adminUserId)) return Unauthorized();

            var success = await _hrService.ApproveHRAsync(id, adminUserId);
            if (!success) return NotFound(new { message = "Company HR record not found." });

            return Ok(new { message = "Company HR account approved successfully." });
        }

        [HttpPut("{id}/reject")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> RejectHR(int id)
        {
            var success = await _hrService.RejectHRAsync(id);
            if (!success) return NotFound(new { message = "Company HR record not found." });

            return Ok(new { message = "Company HR account rejected." });
        }
    }
}