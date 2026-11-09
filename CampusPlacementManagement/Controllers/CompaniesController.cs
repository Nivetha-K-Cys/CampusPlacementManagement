using CampusPlacementManagement.DTOs;
using CampusPlacementManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CampusPlacementManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _service;

        public CompaniesController(ICompanyService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyResponseDto>>> GetAll() =>
            Ok(await _service.GetAllCompaniesAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyResponseDto>> GetById(int id)
        {
            var company = await _service.GetCompanyByIdAsync(id);
            if (company == null) return NotFound();
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyResponseDto>> Create(CompanyCreateDto dto)
        {
            var created = await _service.CreateCompanyAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}