using CampusPlacementManagement.DTOs.College;
using CampusPlacementManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Services.Interfaces
{
    public interface ICollegeService
    {
        Task<College> RegisterCollegeAsync(CollegeRegisterDto dto);
        Task<IEnumerable<College>> GetAllCollegesAsync();
        Task<IEnumerable<College>> GetPendingCollegesAsync();
        Task<bool> ApproveCollegeAsync(int id);
        Task<bool> RejectCollegeAsync(int id);
        Task<bool> SuspendCollegeAsync(int id);
    }
}