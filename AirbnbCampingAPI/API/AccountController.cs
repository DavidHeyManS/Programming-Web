
using AirbnbCamping.Services.Database.CampingServices.Database;
using AirbnbCamping.Services.Database.UserServices.Database;
using AirbnbCamping.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AirbnbCamping.Services.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : Controller
{
    private readonly IUserContext _userDbContext;

    public AccountController(IUserContext userDbContext)
    {
        _userDbContext = userDbContext;
    }

    [HttpGet("profile")]
    [Authorize]
    public IActionResult GetUserProfile()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = _userDbContext.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost("register")]
    public IActionResult RegisterUser(UserRegistration newUser)
    {
        _userDbContext.Users.Add(newUser);
        _userDbContext.SaveChanges();
        return CreatedAtAction(nameof(GetUserProfile), new { id = newUser.Id }, newUser);
    }

    [HttpPut("update")]
    [Authorize]
    public IActionResult UpdateUserProfile(UserProfileUpdate updatedProfile)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = _userDbContext.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            return NotFound();
        }
        user.FullName = updatedProfile.FullName;
        user.Email = updatedProfile.ContactEmail;
        if (!string.IsNullOrEmpty(updatedProfile.NewPassword))
        {
            user.Password = updatedProfile.NewPassword;
        }
        _userDbContext.SaveChanges();
        return NoContent();
    }
}
