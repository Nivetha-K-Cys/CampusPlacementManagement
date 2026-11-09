using CampusPlacementManagement.Data;
using CampusPlacementManagement.Models;
using CampusPlacementManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Repositories.Implementations
{
    public class JobApplicationRepository : IJobApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public JobApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JobApplication>> GetAllApplicationsAsync()
        {
            return await _context.JobApplications
                .Include(j => j.JobPosting)
                .Include(j => j.User)
                .ToListAsync();
        }

        public async Task<JobApplication?> GetApplicationByIdAsync(int id)
        {
            return await _context.JobApplications
                .Include(j => j.JobPosting)
                .Include(j => j.User)
                .FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task AddApplicationAsync(JobApplication application)
        {
            await _context.JobApplications.AddAsync(application);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateApplicationAsync(JobApplication application)
        {
            _context.JobApplications.Update(application);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteApplicationAsync(int id)
        {
            var app = await _context.JobApplications.FindAsync(id);
            if (app != null)
            {
                _context.JobApplications.Remove(app);
                await _context.SaveChangesAsync();
            }
        }
    }
}