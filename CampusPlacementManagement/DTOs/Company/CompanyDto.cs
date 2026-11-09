namespace CampusPlacementManagement.DTOs
{
    public class CompanyCreateDto
    {
        public string CompanyName { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
    }

    public class CompanyResponseDto : CompanyCreateDto
    {
        public int Id { get; set; }
    }
}