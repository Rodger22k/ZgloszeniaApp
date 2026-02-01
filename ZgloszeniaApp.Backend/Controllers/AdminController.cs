using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZgloszeniaApp.Backend.Models;
using ZgloszeniaApp.Shared.Models;

namespace ZgloszeniaApp.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrator")]  // Tylko admin
    public class AdminController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // 1. Pobieranie listy użytkowników
        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            // Pobiera wszystkich użytkowników z bazy, mapuje na DTO
            var users = _userManager.Users; 
            var userList = await users
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Email = u.Email
                })
                .ToListAsync();

            return Ok(userList);
        }

        // 2. Usuwanie użytkownika
        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound("Nie znaleziono użytkownika.");

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Join(" ", result.Errors.Select(e => e.Description));
                return BadRequest(errors);
            }
            return Ok("Użytkownik usunięty pomyślnie.");
        }

        // 3. Edycja e-maila (i ewentualnie nazwy użytkownika)
        [HttpPost("UpdateUserEmail")]
        public async Task<IActionResult> UpdateUserEmail([FromBody] UserDto userDto)
        {
            var user = await _userManager.FindByIdAsync(userDto.Id);
            if (user == null)
                return NotFound("Nie znaleziono użytkownika.");

            user.Email = userDto.Email;   // Zmiana maila
            user.UserName = userDto.Email; 

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Join(" ", result.Errors.Select(e => e.Description));
                return BadRequest(errors);
            }
            return Ok("Email użytkownika zaktualizowany pomyślnie.");
        }

        // 4. Zmiana (reset) hasła użytkownika
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return NotFound("Nie znaleziono użytkownika.");

            
            var removeResult = await _userManager.RemovePasswordAsync(user);
            if (!removeResult.Succeeded)
            {
                var err = string.Join(" ", removeResult.Errors.Select(e => e.Description));
                return BadRequest($"Błąd usuwania starego hasła: {err}");
            }

            var addResult = await _userManager.AddPasswordAsync(user, model.NewPassword);
            if (!addResult.Succeeded)
            {
                var err = string.Join(" ", addResult.Errors.Select(e => e.Description));
                return BadRequest($"Błąd ustawiania nowego hasła: {err}");
            }

            return Ok("Hasło zresetowane pomyślnie.");
        }
    }
}
