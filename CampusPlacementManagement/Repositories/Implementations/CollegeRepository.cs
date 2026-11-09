using CampusPlacementManagement.Data;
using CampusPlacementManagement.Models;
using CampusPlacementManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Repositories.Implementations
{
    public class CollegeRepository : ICollegeRepository
    {
        private readonly ApplicationDbContext _context;

        public CollegeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<College>> GetAllAsync() => await _context.Colleges.ToListAsync();

        public async Task<College?> GetByIdAsync(int id) => await _context.Colleges.FindAsync(id);

        public async Task<IEnumerable<College>> GetPendingCollegesAsync() =>
            await _context.Colleges.Where(c => c.Status == "Pending").ToListAsync();

        public async Task AddAsync(College college)
        {
            await _context.Colleges.AddAsync(college);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(College college)
        {
            _context.Colleges.Update(college);
            await _context.SaveChangesAsync();
        }
    }
}