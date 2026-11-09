using System.ComponentModel.DataAnnotations;

namespace CampusPlacementManagement.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        public string Industry { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        [EmailAddress]
        public string ContactEmail { get; set; } = string.Empty;

        public ICollection<JobPosting> JobPostings { get; set; } = new List<JobPosting>();
    }
}