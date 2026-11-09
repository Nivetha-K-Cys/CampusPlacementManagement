using CampusPlacementManagement.Models;

namespace CampusPlacementManagement.Repositories
{
    public interface IJobPostingRepository
    {
        Task<IEnumerable<JobPosting>> GetAllAsync();
        Task<JobPosting?> GetByIdAsync(int id);
        Task AddAsync(JobPosting jobPosting);
        Task SaveChangesAsync();
    }
}