using CampusPlacementManagement.DTOs.User;

namespace CampusPlacementManagement.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> GetUsersAsync();
        Task<UserResponseDto?> GetUserByIdAsync(string id);
    }
}