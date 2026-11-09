using CampusPlacementManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Repositories.Interfaces
{
    public interface ICollegeRepository
    {
        Task<IEnumerable<College>> GetAllAsync();
        Task<College?> GetByIdAsync(int id); // ? added here
        Task<IEnumerable<College>> GetPendingCollegesAsync();
        Task AddAsync(College college);
        Task UpdateAsync(College college);
    }
}