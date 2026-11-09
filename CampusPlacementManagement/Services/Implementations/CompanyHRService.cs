using CampusPlacementManagement.Models;
using CampusPlacementManagement.Repositories.Interfaces;
using CampusPlacementManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Services.Implementations
{
    public class CompanyHRService : ICompanyHRService
    {
        private readonly ICompanyHRRepository _hrRepo;

        public CompanyHRService(ICompanyHRRepository hrRepo)
        {
            _hrRepo = hrRepo;
        }

        public async Task<IEnumerable<CompanyHR>> GetPendingHRsAsync() =>
            await _hrRepo.GetPendingHRsAsync();

        public async Task<bool> ApproveHRAsync(int id, string adminUserId)
        {
            var hr = await _hrRepo.GetByIdAsync(id);
            if (hr == null) return false;

            hr.ApprovedBy = adminUserId;
            hr.ApprovedAt = DateTime.UtcNow;

            // Also update ApplicationUser status if needed
            if (hr.User != null)
            {
                hr.User.AccountStatus = "Approved";
            }

            await _hrRepo.UpdateAsync(hr);
            return true;
        }

        public async Task<bool> RejectHRAsync(int id)
        {
            var hr = await _hrRepo.GetByIdAsync(id);
            if (hr == null) return false;

            if (hr.User != null)
            {
                hr.User.AccountStatus = "Rejected";
            }

            await _hrRepo.UpdateAsync(hr);
            return true;
        }
    }
}