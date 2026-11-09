using CampusPlacementManagement.Data;
using CampusPlacementManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CampusPlacementManagement.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Company>> GetAllAsync() =>
            await _context.Companies.Include(c => c.JobPostings).ToListAsync();

        public async Task<Company?> GetByIdAsync(int id) =>
            await _context.Companies.Include(c => c.JobPostings).FirstOrDefaultAsync(c => c.Id == id);

        public async Task AddAsync(Company company) => await _context.Companies.AddAsync(company);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}