using CampusPlacementManagement.Data;
using CampusPlacementManagement.Models;
using CampusPlacementManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Repositories.Implementations
{
    public class CompanyHRRepository : ICompanyHRRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyHRRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CompanyHR>> GetPendingHRsAsync() =>
            await _context.CompanyHRs
                .Include(h => h.Company)
                .Include(h => h.User)
                .Where(h => h.ApprovedBy == null) // Pending approval
                .ToListAsync();

        public async Task<CompanyHR?> GetByIdAsync(int id) =>
            await _context.CompanyHRs
                .Include(h => h.Company)
                .Include(h => h.User)
                .FirstOrDefaultAsync(h => h.CompanyHRId == id);

        public async Task<CompanyHR?> GetByUserIdAsync(string userId) =>
            await _context.CompanyHRs
                .Include(h => h.Company)
                .FirstOrDefaultAsync(h => h.UserId == userId);

        public async Task AddAsync(CompanyHR companyHR)
        {
            await _context.CompanyHRs.AddAsync(companyHR);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CompanyHR companyHR)
        {
            _context.CompanyHRs.Update(companyHR);
            await _context.SaveChangesAsync();
        }
    }
}