
using AirbnbCamping.Core.Enum;

namespace AirbnbCamping.Core.Model;

public class UserAccount
{
    public int UserId { get; set; }
    public string FullName { get; set; }
    public string ContactEmail { get; set; }
    public string HashedPassword { get; set; }
    public List<Reservation> Reservations { get; set; }
    public UserRole Role { get; set; }
    
    public UserAccount() 
    {
        Reservations = new List<Reservation>();
    }
}
