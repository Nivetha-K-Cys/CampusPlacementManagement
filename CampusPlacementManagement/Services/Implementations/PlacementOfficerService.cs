using CampusPlacementManagement.DTOs.PlacementOfficer;
using CampusPlacementManagement.Models;
using CampusPlacementManagement.Repositories.Interfaces;
using CampusPlacementManagement.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Services.Implementations
{
    public class PlacementOfficerService : IPlacementOfficerService
    {
        private readonly IPlacementOfficerRepository _officerRepo;
        private readonly ICollegeRepository _collegeRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        public PlacementOfficerService(IPlacementOfficerRepository officerRepo, ICollegeRepository collegeRepo, UserManager<ApplicationUser> userManager)
        {
            _officerRepo = officerRepo;
            _collegeRepo = collegeRepo;
            _userManager = userManager;
        }

        public async Task<bool> RegisterOfficerAsync(PlacementOfficerRegisterDto dto)
        {
            var college = await _collegeRepo.GetByIdAsync(dto.CollegeId);
            if (college == null || college.Status != "Approved") return false; // Must be approved college[cite: 7]

            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                FullName = dto.FullName,
                PhoneNumber = dto.PhoneNumber,
                AccountStatus = "Pending",
                CreatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded) return false;

            await _userManager.AddToRoleAsync(user, "PlacementOfficer");

            var officer = new PlacementOfficer
            {
                UserId = user.Id,
                CollegeId = dto.CollegeId,
                Designation = dto.Designation,
                Status = "Pending"
            };

            await _officerRepo.AddAsync(officer);
            return true;
        }

        public async Task<IEnumerable<PlacementOfficer>> GetPendingOfficersAsync() => await _officerRepo.GetPendingOfficersAsync();

        public async Task<bool> ApproveOfficerAsync(int id, string adminUserId)
        {
            var officer = await _officerRepo.GetByIdAsync(id);
            if (officer == null) return false;

            officer.Status = "Approved";
            officer.ApprovedBy = adminUserId;
            officer.ApprovedAt = DateTime.UtcNow;
            await _officerRepo.UpdateAsync(officer);

            var user = await _userManager.FindByIdAsync(officer.UserId);
            if (user != null)
            {
                user.AccountStatus = "Approved";
                await _userManager.UpdateAsync(user);
            }

            return true;
        }

        public async Task<bool> RejectOfficerAsync(int id)
        {
            var officer = await _officerRepo.GetByIdAsync(id);
            if (officer == null) return false;

            officer.Status = "Rejected";
            await _officerRepo.UpdateAsync(officer);
            return true;
        }
    }
}