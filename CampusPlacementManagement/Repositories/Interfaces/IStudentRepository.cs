using CampusPlacementManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetPendingStudentsAsync();
        Task<Student?> GetByIdAsync(int id);           // ? added here
        Task<Student?> GetByUserIdAsync(string userId); // ? added here
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
    }
}