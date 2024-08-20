using AirbnbCamping.Core.Model;

namespace AirbnbCamping.Services.Database.CampingServices.Database;

public interface ICampingContext
{
    ICore.Enumerable<Camping> GetAll();
    Camping GetById(int id);
    void AddCamping(Camping camping);
    Camping UpdateCamping(Camping camping);

}
