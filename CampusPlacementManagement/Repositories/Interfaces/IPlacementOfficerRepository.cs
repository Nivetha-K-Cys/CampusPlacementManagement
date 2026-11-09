using CampusPlacementManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Repositories.Interfaces
{
    public interface IPlacementOfficerRepository
    {
        Task<IEnumerable<PlacementOfficer>> GetPendingOfficersAsync();
        Task<PlacementOfficer?> GetByIdAsync(int id);           // ? added here
        Task<PlacementOfficer?> GetByUserIdAsync(string userId);
        Task AddAsync(PlacementOfficer officer);
        Task UpdateAsync(PlacementOfficer officer);
    }
}