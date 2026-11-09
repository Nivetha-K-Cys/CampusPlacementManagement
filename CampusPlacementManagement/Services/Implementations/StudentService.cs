using CampusPlacementManagement.DTOs.Student;
using CampusPlacementManagement.Models;
using CampusPlacementManagement.Repositories.Interfaces;
using CampusPlacementManagement.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepo;
        private readonly ICollegeRepository _collegeRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentService(IStudentRepository studentRepo, ICollegeRepository collegeRepo, UserManager<ApplicationUser> userManager)
        {
            _studentRepo = studentRepo;
            _collegeRepo = collegeRepo;
            _userManager = userManager;
        }

        public async Task<bool> RegisterStudentAsync(StudentRegisterDto dto)
        {
            var college = await _collegeRepo.GetByIdAsync(dto.CollegeId);
            if (college == null || college.Status != "Approved") return false;

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

            await _userManager.AddToRoleAsync(user, "Student");

            var student = new Student
            {
                UserId = user.Id,
                CollegeId = dto.CollegeId,
                RollNumber = dto.RollNumber,
                Department = dto.Department,
                CGPA = dto.CGPA,
                GraduationYear = dto.GraduationYear,
                Status = "Pending"
            };

            await _studentRepo.AddAsync(student);
            return true;
        }

        public async Task<IEnumerable<Student>> GetPendingStudentsAsync() => await _studentRepo.GetPendingStudentsAsync();

        public async Task<bool> ApproveStudentAsync(int id)
        {
            var student = await _studentRepo.GetByIdAsync(id);
            if (student == null) return false;

            student.Status = "Approved";
            await _studentRepo.UpdateAsync(student);

            var user = await _userManager.FindByIdAsync(student.UserId);
            if (user != null)
            {
                user.AccountStatus = "Approved";
                await _userManager.UpdateAsync(user);
            }

            return true;
        }

        public async Task<bool> RejectStudentAsync(int id)
        {
            var student = await _studentRepo.GetByIdAsync(id);
            if (student == null) return false;

            student.Status = "Rejected";
            await _studentRepo.UpdateAsync(student);
            return true;
        }
    }
}