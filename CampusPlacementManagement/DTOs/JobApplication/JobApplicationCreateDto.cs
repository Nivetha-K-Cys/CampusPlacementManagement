namespace CampusPlacementManagement.DTOs
{
    public class JobApplicationCreateDto
    {
        public int JobPostingId { get; set; }
        public required string UserId { get; set; } // Fixed warning by adding 'required'
    }
}