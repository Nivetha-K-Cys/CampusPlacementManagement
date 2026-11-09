using CampusPlacementManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Repositories.Interfaces
{
    public interface IJobApplicationRepository
    {
        Task<IEnumerable<JobApplication>> GetAllApplicationsAsync();
        Task<JobApplication?> GetApplicationByIdAsync(int id);
        Task AddApplicationAsync(JobApplication application);
        Task UpdateApplicationAsync(JobApplication application);
        Task DeleteApplicationAsync(int id);
    }
}