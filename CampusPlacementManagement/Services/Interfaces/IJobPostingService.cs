using CampusPlacementManagement.DTOs;

namespace CampusPlacementManagement.Services
{
    public interface IJobPostingService
    {
        Task<IEnumerable<JobPostingResponseDto>> GetAllJobPostingsAsync();
        Task<JobPostingResponseDto?> GetJobPostingByIdAsync(int id);
        Task<JobPostingResponseDto> CreateJobPostingAsync(JobPostingCreateDto dto);
    }
}