using CampusPlacementManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Repositories.Interfaces
{
    public interface ICompanyHRRepository
    {
        Task<IEnumerable<CompanyHR>> GetPendingHRsAsync();
        Task<CompanyHR?> GetByIdAsync(int id);
        Task<CompanyHR?> GetByUserIdAsync(string userId);
        Task AddAsync(CompanyHR companyHR);
        Task UpdateAsync(CompanyHR companyHR);
    }
}