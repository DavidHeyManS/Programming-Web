using AirbnbCamping.Core.Model;

namespace AirbnbCamping.Services.Database.UserServices.Database;

public interface IUserContext
{
    ICore.Enumerable<User> GetAll();
    void AddUser(User user);
    User GetById(int id);
    User UpdateUser(User user);


}
