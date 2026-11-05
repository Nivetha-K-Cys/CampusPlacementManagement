namespace CampusPlacementManagement.DTOs.User
{
    public class UserResponseDto
    {
        public required string Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string FullName { get; set; }
        public required string AccountStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}