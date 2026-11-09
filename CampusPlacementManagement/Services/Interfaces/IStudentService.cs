using CampusPlacementManagement.DTOs.Student;
using CampusPlacementManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Services.Interfaces
{
    public interface IStudentService
    {
        Task<bool> RegisterStudentAsync(StudentRegisterDto dto);
        Task<IEnumerable<Student>> GetPendingStudentsAsync();
        Task<bool> ApproveStudentAsync(int id);
        Task<bool> RejectStudentAsync(int id);
    }
}