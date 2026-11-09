using CampusPlacementManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Services.Interfaces
{
    public interface ICompanyHRService
    {
        Task<IEnumerable<CompanyHR>> GetPendingHRsAsync();
        Task<bool> ApproveHRAsync(int id, string adminUserId);
        Task<bool> RejectHRAsync(int id);
    }
}