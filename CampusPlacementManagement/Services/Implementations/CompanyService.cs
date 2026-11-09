using CampusPlacementManagement.DTOs;
using CampusPlacementManagement.Models;
using CampusPlacementManagement.Repositories;

namespace CampusPlacementManagement.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repo;

        public CompanyService(ICompanyRepository repo) => _repo = repo;

        public async Task<IEnumerable<CompanyResponseDto>> GetAllCompaniesAsync()
        {
            var companies = await _repo.GetAllAsync();
            return companies.Select(c => new CompanyResponseDto
            {
                Id = c.Id,
                CompanyName = c.CompanyName,
                Industry = c.Industry,
                Location = c.Location,
                ContactEmail = c.ContactEmail
            });
        }

        public async Task<CompanyResponseDto?> GetCompanyByIdAsync(int id)
        {
            var c = await _repo.GetByIdAsync(id);
            if (c == null) return null;

            return new CompanyResponseDto
            {
                Id = c.Id,
                CompanyName = c.CompanyName,
                Industry = c.Industry,
                Location = c.Location,
                ContactEmail = c.ContactEmail
            };
        }

        public async Task<CompanyResponseDto> CreateCompanyAsync(CompanyCreateDto dto)
        {
            var company = new Company
            {
                CompanyName = dto.CompanyName,
                Industry = dto.Industry,
                Location = dto.Location,
                ContactEmail = dto.ContactEmail
            };

            await _repo.AddAsync(company);
            await _repo.SaveChangesAsync();

            return new CompanyResponseDto
            {
                Id = company.Id,
                CompanyName = company.CompanyName,
                Industry = company.Industry,
                Location = company.Location,
                ContactEmail = company.ContactEmail
            };
        }
    }
}