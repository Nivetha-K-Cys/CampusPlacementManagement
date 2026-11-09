using CampusPlacementManagement.DTOs;
using CampusPlacementManagement.Models;
using CampusPlacementManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CampusPlacementManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthController(UserManager<ApplicationUser> userManager,
                              SignInManager<ApplicationUser> signInManager,
                              ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized(new { message = "Invalid Email!" });

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized(new { message = "Invalid Password!" });

            return Ok(new
            {
                message = "Login successful!",
                token = _tokenService.CreateToken(user),
                email = user.Email,
                userId = user.Id
            });
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userEmail = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value
                            ?? User.FindFirst(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email)?.Value;

            if (userEmail == null) return Unauthorized();

            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null) return NotFound();

            return Ok(new
            {
                id = user.Id,
                email = user.Email,
                userName = user.UserName
            });
        } // <-- End of GetCurrentUser method

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null) return NotFound("User not found");

            // Remove old password hash and set new hashed password properly
            var removePassword = await _userManager.RemovePasswordAsync(user);
            var addPassword = await _userManager.AddPasswordAsync(user, dto.Password);

            if (addPassword.Succeeded)
            {
                return Ok(new { message = "Password reset and hashed successfully! Now you can login." });
            }

            return BadRequest(addPassword.Errors);
        }
    }
}