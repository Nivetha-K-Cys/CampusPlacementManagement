using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusPlacementManagement.Models
{
    public class CompanyHR
    {
        [Key]
        public int CompanyHRId { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public int CompanyId { get; set; }

        [MaxLength(100)]
        public string? Designation { get; set; }

        [MaxLength(450)]
        public string? ApprovedBy { get; set; } // FK to ApplicationUsers (SuperAdmin)

        public DateTime? ApprovedAt { get; set; }

        // Navigation Properties
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }

        [ForeignKey("ApprovedBy")]
        public ApplicationUser? Approver { get; set; }
    }
}