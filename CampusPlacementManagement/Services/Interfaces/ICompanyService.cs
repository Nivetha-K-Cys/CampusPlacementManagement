using CampusPlacementManagement.DTOs;

namespace CampusPlacementManagement.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyResponseDto>> GetAllCompaniesAsync();
        Task<CompanyResponseDto?> GetCompanyByIdAsync(int id);
        Task<CompanyResponseDto> CreateCompanyAsync(CompanyCreateDto dto);
    }
}