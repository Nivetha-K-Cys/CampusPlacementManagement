using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusPlacementManagement.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty; // FK to ApplicationUser

        [Required]
        public int CollegeId { get; set; } // FK to College

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

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected

        // Navigation Properties
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        [ForeignKey("CollegeId")]
        public College? College { get; set; }
    }
}