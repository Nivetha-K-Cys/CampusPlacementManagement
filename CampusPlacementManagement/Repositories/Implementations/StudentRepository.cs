using CampusPlacementManagement.Data;
using CampusPlacementManagement.Models;
using CampusPlacementManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetPendingStudentsAsync() =>
            await _context.Students
                .Include(s => s.College)
                .Include(s => s.User)
                .Where(s => s.Status == "Pending")
                .ToListAsync();

        public async Task<Student?> GetByIdAsync(int id) =>
            await _context.Students
                .Include(s => s.College)
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.StudentId == id);

        public async Task<Student?> GetByUserIdAsync(string userId) =>
            await _context.Students
                .Include(s => s.College)
                .FirstOrDefaultAsync(s => s.UserId == userId);

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}