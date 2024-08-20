
using AirbnbCamping.Core.Model;

namespace AirbnbCamping.Services.Controllers
{
    public record BookingRequest(DateTime StartDate, DateTime EndDate);
}
