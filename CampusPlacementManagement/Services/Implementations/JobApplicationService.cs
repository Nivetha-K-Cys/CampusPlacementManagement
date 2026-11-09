using CampusPlacementManagement.Models;
using CampusPlacementManagement.Repositories.Interfaces;
using CampusPlacementManagement.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Services.Implementations
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IJobApplicationRepository _repository;

        public JobApplicationService(IJobApplicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<JobApplication>> GetAllApplicationsAsync()
        {
            return await _repository.GetAllApplicationsAsync();
        }

        public async Task<JobApplication?> GetApplicationByIdAsync(int id)
        {
            return await _repository.GetApplicationByIdAsync(id);
        }

        public async Task AddApplicationAsync(JobApplication application)
        {
            await _repository.AddApplicationAsync(application);
        }

        public async Task UpdateApplicationAsync(JobApplication application)
        {
            await _repository.UpdateApplicationAsync(application);
        }

        public async Task DeleteApplicationAsync(int id)
        {
            await _repository.DeleteApplicationAsync(id);
        }
    }
}