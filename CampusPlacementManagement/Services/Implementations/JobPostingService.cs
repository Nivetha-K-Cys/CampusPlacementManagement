using CampusPlacementManagement.DTOs;
using CampusPlacementManagement.Models;
using CampusPlacementManagement.Repositories;

namespace CampusPlacementManagement.Services
{
    public class JobPostingService : IJobPostingService
    {
        private readonly IJobPostingRepository _repo;

        public JobPostingService(IJobPostingRepository repo) => _repo = repo;

        public async Task<IEnumerable<JobPostingResponseDto>> GetAllJobPostingsAsync()
        {
            var jobs = await _repo.GetAllAsync();
            return jobs.Select(j => new JobPostingResponseDto
            {
                Id = j.Id,
                Title = j.Title,
                Description = j.Description,
                PackageLpa = j.PackageLpa,
                Deadline = j.Deadline,
                CreatedAt = j.CreatedAt,
                CompanyId = j.CompanyId,
                CompanyName = j.Company?.CompanyName ?? string.Empty
            });
        }

        public async Task<JobPostingResponseDto?> GetJobPostingByIdAsync(int id)
        {
            var j = await _repo.GetByIdAsync(id);
            if (j == null) return null;

            return new JobPostingResponseDto
            {
                Id = j.Id,
                Title = j.Title,
                Description = j.Description,
                PackageLpa = j.PackageLpa,
                Deadline = j.Deadline,
                CreatedAt = j.CreatedAt,
                CompanyId = j.CompanyId,
                CompanyName = j.Company?.CompanyName ?? string.Empty
            };
        }

        public async Task<JobPostingResponseDto> CreateJobPostingAsync(JobPostingCreateDto dto)
        {
            var job = new JobPosting
            {
                Title = dto.Title,
                Description = dto.Description,
                PackageLpa = dto.PackageLpa,
                Deadline = dto.Deadline,
                CompanyId = dto.CompanyId
            };

            await _repo.AddAsync(job);
            await _repo.SaveChangesAsync();

            // Fetch back with company details for response
            var created = await _repo.GetByIdAsync(job.Id);

            return new JobPostingResponseDto
            {
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                PackageLpa = job.PackageLpa,
                Deadline = job.Deadline,
                CreatedAt = job.CreatedAt,
                CompanyId = job.CompanyId,
                CompanyName = created?.Company?.CompanyName ?? string.Empty
            };
        }
    }
}