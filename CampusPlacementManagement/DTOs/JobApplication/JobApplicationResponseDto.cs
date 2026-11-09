using System;
namespace CampusPlacementManagement.DTOs
{
    public class JobApplicationResponseDto
    {
        public int Id { get; set; }
        public int JobPostingId { get; set; }
        public string? JobTitle { get; set; }
        public int UserId { get; set; }
        public string? StudentName { get; set; }
        public DateTime AppliedDate { get; set; }
        public string Status { get; set; } = "Pending";
    }
}