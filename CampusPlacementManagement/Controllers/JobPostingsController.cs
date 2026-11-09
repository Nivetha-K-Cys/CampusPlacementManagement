using CampusPlacementManagement.DTOs;
using CampusPlacementManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CampusPlacementManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostingsController : ControllerBase
    {
        private readonly IJobPostingService _service;

        public JobPostingsController(IJobPostingService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobPostingResponseDto>>> GetAll() =>
            Ok(await _service.GetAllJobPostingsAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<JobPostingResponseDto>> GetById(int id)
        {
            var job = await _service.GetJobPostingByIdAsync(id);
            if (job == null) return NotFound();
            return Ok(job);
        }

        [HttpPost]
        public async Task<ActionResult<JobPostingResponseDto>> Create(JobPostingCreateDto dto)
        {
            var created = await _service.CreateJobPostingAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}