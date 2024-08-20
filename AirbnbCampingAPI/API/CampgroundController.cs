
using AirbnbCamping.Services.Database.CampingServices.Database;
using AirbnbCamping.Services.Database.UserServices.Database;
using AirbnbCamping.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace AirbnbCamping.Services.Controllers;

[EnableCors]
[Route("api/[controller]")]
[ApiController]
public class CampgroundController : ControllerBase
{
    private readonly ICampingContext _campingDbContext;

    public CampgroundController(ICampingContext campingDbContext)
    {
        _campingDbContext = campingDbContext;
    }

    [HttpGet]
    public IActionResult GetAllCampgrounds()
    {
        var campgrounds = _campingDbContext.Campgrounds.ToList();
        return Ok(campgrounds);
    }

    [HttpGet("{id}")]
    public IActionResult GetCampgroundById(int id)
    {
        var campground = _campingDbContext.Campgrounds.FirstOrDefault(c => c.Id == id);
        if (campground == null)
        {
            return NotFound();
        }
        return Ok(campground);
    }

    [HttpPost]
    public IActionResult AddCampground(Campground newCampground)
    {
        _campingDbContext.Campgrounds.Add(newCampground);
        _campingDbContext.SaveChanges();
        return CreatedAtAction(nameof(GetCampgroundById), new { id = newCampground.Id }, newCampground);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCampground(int id, Campground updatedCampground)
    {
        var existingCampground = _campingDbContext.Campgrounds.FirstOrDefault(c => c.Id == id);
        if (existingCampground == null)
        {
            return NotFound();
        }
        existingCampground.Name = updatedCampground.Name;
        existingCampground.Description = updatedCampground.Description;
        existingCampground.PricePerNight = updatedCampground.PricePerNight;

        _campingDbContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCampground(int id)
    {
        var campground = _campingDbContext.Campgrounds.FirstOrDefault(c => c.Id == id);
        if (campground == null)
        {
            return NotFound();
        }
        _campingDbContext.Campgrounds.Remove(campground);
        _campingDbContext.SaveChanges();
        return NoContent();
    }
}
