
using Microsoft.VisualBasic;

namespace AirbnbCamping.Core.Model;

public class Reservation
{
    public Reservation()
    {
        
    }

    public Reservation(DateTime checkIn, DateTime checkOut, Campground campsite)
    {
        CheckIn = checkIn;
        CheckOut = checkOut;
        Campsite = campsite;
        TotalCost = CalculateTotalCost();
    }

    public int ReservationId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public Campground Campsite { get; set; }
    public UserAccount User { get; set; }
    public decimal TotalCost { get; private set; }

    private decimal CalculateTotalCost()
    {
        return (decimal)(CheckOut - CheckIn).TotalDays * Campsite.PricePerNight;
    }
}
