using CampusPlacementManagement.Data;
using CampusPlacementManagement.Models;
using CampusPlacementManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Repositories.Implementations
{
    public class PlacementOfficerRepository : IPlacementOfficerRepository
    {
        private readonly ApplicationDbContext _context;

        public PlacementOfficerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlacementOfficer>> GetPendingOfficersAsync() =>
            await _context.PlacementOfficers
                .Include(p => p.College)
                .Include(p => p.User)
                .Where(p => p.Status == "Pending")
                .ToListAsync();

        public async Task<PlacementOfficer> GetByIdAsync(int id) =>
            await _context.PlacementOfficers
                .Include(p => p.College)
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.PlacementOfficerId == id);

        public async Task<PlacementOfficer> GetByUserIdAsync(string userId) =>
            await _context.PlacementOfficers
                .Include(p => p.College)
                .FirstOrDefaultAsync(p => p.UserId == userId);

        public async Task AddAsync(PlacementOfficer officer)
        {
            await _context.PlacementOfficers.AddAsync(officer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PlacementOfficer officer)
        {
            _context.PlacementOfficers.Update(officer);
            await _context.SaveChangesAsync();
        }
    }
}