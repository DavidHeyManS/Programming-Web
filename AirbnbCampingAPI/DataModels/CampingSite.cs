
namespace AirbnbCamping.Core.Model;

public class Campground
{
    public Campground()
    {
        
    }

    public Campground(int campgroundId, string title, string details, decimal nightlyRate)
    {
        CampgroundId = campgroundId;
        Title = title;
        Details = details;
        NightlyRate = nightlyRate;
    }
    public int CampgroundId { get; set; }
    public string? Title { get; set; }
    public string? Details { get; set; }
    public decimal NightlyRate { get; set; }
    public string? Location { get; set; }
    public string? Amenities { get; set; }
}
