using CampusPlacementManagement.DTOs.PlacementOfficer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Services.Interfaces
{
    public interface IPlacementOfficerService
    {
        Task<bool> RegisterOfficerAsync(PlacementOfficerRegisterDto dto);
        Task<IEnumerable<Models.PlacementOfficer>> GetPendingOfficersAsync();
        Task<bool> ApproveOfficerAsync(int id, string adminUserId);
        Task<bool> RejectOfficerAsync(int id);
    }
}