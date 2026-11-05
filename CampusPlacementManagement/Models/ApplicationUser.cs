using Microsoft.AspNetCore.Identity;

namespace CampusPlacementManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public string AccountStatus { get; set; } = "Pending"; // Pending, Approved, Rejected, Suspended, Inactive[cite: 21]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}