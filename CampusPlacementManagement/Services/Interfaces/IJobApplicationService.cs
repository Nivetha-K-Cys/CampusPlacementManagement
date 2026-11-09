using CampusPlacementManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Services.Interfaces
{
    public interface IJobApplicationService
    {
        Task<IEnumerable<JobApplication>> GetAllApplicationsAsync();
        Task<JobApplication?> GetApplicationByIdAsync(int id);
        Task AddApplicationAsync(JobApplication application);
        Task UpdateApplicationAsync(JobApplication application);
        Task DeleteApplicationAsync(int id);
    }
}