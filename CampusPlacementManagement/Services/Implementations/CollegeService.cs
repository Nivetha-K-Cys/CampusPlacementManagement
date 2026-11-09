using CampusPlacementManagement.DTOs.College;
using CampusPlacementManagement.Models;
using CampusPlacementManagement.Repositories.Interfaces;
using CampusPlacementManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Services.Implementations
{
    public class CollegeService : ICollegeService
    {
        private readonly ICollegeRepository _collegeRepo;

        public CollegeService(ICollegeRepository collegeRepo)
        {
            _collegeRepo = collegeRepo;
        }

        public async Task<College> RegisterCollegeAsync(CollegeRegisterDto dto)
        {
            var collegeObj = new College
            {
                CollegeName = dto.CollegeName,
                CollegeCode = dto.CollegeCode,
                UniversityName = dto.UniversityName,
                OfficialEmail = dto.OfficialEmail,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
                Website = dto.Website,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };

            await _collegeRepo.AddAsync(collegeObj);
            return collegeObj;
        }

        public async Task<IEnumerable<College>> GetAllCollegesAsync() => await _collegeRepo.GetAllAsync();

        public async Task<IEnumerable<College>> GetPendingCollegesAsync() => await _collegeRepo.GetPendingCollegesAsync();

        public async Task<bool> ApproveCollegeAsync(int id)
        {
            var collegeObj = await _collegeRepo.GetByIdAsync(id);
            if (collegeObj == null) return false;

            collegeObj.Status = "Approved";
            await _collegeRepo.UpdateAsync(collegeObj);
            return true;
        }

        public async Task<bool> RejectCollegeAsync(int id)
        {
            var collegeObj = await _collegeRepo.GetByIdAsync(id);
            if (collegeObj == null) return false;

            collegeObj.Status = "Rejected";
            await _collegeRepo.UpdateAsync(collegeObj);
            return true;
        }

        public async Task<bool> SuspendCollegeAsync(int id)
        {
            var collegeObj = await _collegeRepo.GetByIdAsync(id);
            if (collegeObj == null) return false;

            collegeObj.Status = "Suspended";
            await _collegeRepo.UpdateAsync(collegeObj);
            return true;
        }
    }
}