using CampusPlacementManagement.DTOs.User;
using CampusPlacementManagement.Repositories.Interfaces;
using CampusPlacementManagement.Services.Interfaces;

namespace CampusPlacementManagement.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserResponseDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.Select(u => new UserResponseDto
            {
                Id = u.Id,
                UserName = u.UserName ?? string.Empty,
                Email = u.Email ?? string.Empty,
                FullName = u.FullName,
                AccountStatus = u.AccountStatus,
                CreatedAt = u.CreatedAt
            });
        }

        public async Task<UserResponseDto?> GetUserByIdAsync(string id)
        {
            var u = await _userRepository.GetUserByIdAsync(id);
            if (u == null) return null;

            return new UserResponseDto
            {
                Id = u.Id,
                UserName = u.UserName ?? string.Empty,
                Email = u.Email ?? string.Empty,
                FullName = u.FullName,
                AccountStatus = u.AccountStatus,
                CreatedAt = u.CreatedAt
            };
        }
    }
}