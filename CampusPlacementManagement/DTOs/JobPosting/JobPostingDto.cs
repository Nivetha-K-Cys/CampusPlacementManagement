namespace CampusPlacementManagement.DTOs
{
    public class JobPostingCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal PackageLpa { get; set; }
        public DateTime Deadline { get; set; }
        public int CompanyId { get; set; }
    }

    public class JobPostingResponseDto : JobPostingCreateDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CompanyName { get; set; } = string.Empty;
    }
}