using CampusPlacementManagement.Models;

namespace CampusPlacementManagement.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user);
    }
}