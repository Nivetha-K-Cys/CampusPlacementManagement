using System.ComponentModel.DataAnnotations;

namespace CampusPlacementManagement.DTOs.College
{
    public class CollegeRegisterDto
    {
        [Required]
        [MaxLength(200)]
        public string CollegeName { get; set; }

        [Required]
        [MaxLength(50)]
        public string CollegeCode { get; set; }

        [MaxLength(200)]
        public string UniversityName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string OfficialEmail { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(500)]
        public string Address { get; set; }

        [MaxLength(255)]
        public string Website { get; set; }
    }
}