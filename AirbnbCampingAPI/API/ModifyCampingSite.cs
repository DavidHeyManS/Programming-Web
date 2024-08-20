
namespace AirbnbCamping.Services.Controllers
{
    public class ModifyCampground
    {
        public int CampgroundId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PricePerNight { get; set; }

        public ModifyCampground(int campgroundId, string name, string description, decimal pricePerNight)
        {
            CampgroundId = campgroundId;
            Name = name;
            Description = description;
            PricePerNight = pricePerNight;
        }
    }
}
