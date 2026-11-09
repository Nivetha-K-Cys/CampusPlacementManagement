using CampusPlacementManagement.Data;
using CampusPlacementManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CampusPlacementManagement.Repositories
{
    public class JobPostingRepository : IJobPostingRepository
    {
        private readonly ApplicationDbContext _context;

        public JobPostingRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<JobPosting>> GetAllAsync() =>
            await _context.JobPostings.Include(j => j.Company).ToListAsync();

        public async Task<JobPosting?> GetByIdAsync(int id) =>
            await _context.JobPostings.Include(j => j.Company).FirstOrDefaultAsync(j => j.Id == id);

        public async Task AddAsync(JobPosting jobPosting) => await _context.JobPostings.AddAsync(jobPosting);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}