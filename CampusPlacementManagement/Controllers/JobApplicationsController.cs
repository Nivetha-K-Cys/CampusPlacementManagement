using CampusPlacementManagement.DTOs;
using CampusPlacementManagement.Models;
using CampusPlacementManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly IJobApplicationService _service;

        public JobApplicationsController(IJobApplicationService service)
        {
            _service = service;
        }

        // GET: api/JobApplications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobApplication>>> GetAllApplications()
        {
            var applications = await _service.GetAllApplicationsAsync();
            return Ok(applications);
        }

        // GET: api/JobApplications/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<JobApplication>> GetApplicationById(int id)
        {
            var application = await _service.GetApplicationByIdAsync(id);
            if (application == null) return NotFound();
            return Ok(application);
        }

        // POST: api/JobApplications
        [HttpPost]
        public async Task<IActionResult> CreateApplication([FromBody] JobApplicationCreateDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var application = new JobApplication
            {
                JobPostingId = createDto.JobPostingId,
                UserId = createDto.UserId,
                AppliedDate = System.DateTime.UtcNow,
                Status = "Pending"
            };

            await _service.AddApplicationAsync(application);
            return Ok(new { message = "Job applied successfully!", application.Id });
        }
    }
}