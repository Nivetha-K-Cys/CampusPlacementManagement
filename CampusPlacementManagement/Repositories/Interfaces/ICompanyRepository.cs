using CampusPlacementManagement.Models;

namespace CampusPlacementManagement.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllAsync();
        Task<Company?> GetByIdAsync(int id);
        Task AddAsync(Company company);
        Task SaveChangesAsync();
    }
}