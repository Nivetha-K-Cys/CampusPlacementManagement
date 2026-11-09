using System.ComponentModel.DataAnnotations;

namespace CampusPlacementManagement.DTOs.Student
{
    public class StudentRegisterDto
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public int CollegeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string RollNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Department { get; set; } = string.Empty;

        [Required]
        public double CGPA { get; set; }

        [Required]
        public int GraduationYear { get; set; }
    }
}