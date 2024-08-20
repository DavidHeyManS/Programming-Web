using AirbnbCamping.Services.Controllers;
using AirbnbCamping.Core.Model;
using LiteDB;
using System.Collections.Generic;

namespace AirbnbCamping.Services.Database.UserServices.Database;

public class UserContext : IUserContext
{
    private readonly string _connectionString = @"Filename=campingdatabase.db;connection=shared";

    public void Add(User user)
    {
        using var database = new LiteServices.Database(_connectionString);
        var collection = database.GetCollection<User>("User");
        collection.Insert(user);
    }

    public void AddUser(User user)
    {
        using var database = new LiteServices.Database(_connectionString);
        var collection = database.GetCollection<User>("User");
        collection.Insert(user);
    }

    public ICore.Enumerable<User> GetAll()
    {
        using var database = new LiteServices.Database(_connectionString);
        var collection = database.GetCollection<User>("User");
        return collection.FindAll();
    }

    public User GetById(int id)
    {
        using var database = new LiteServices.Database(_connectionString);
        var collection = database.GetCollection<User>("User");
        return collection.FindById(id);
    }

    public User UpdateUser(User user)
    {
        using var database = new LiteServices.Database(_connectionString);
        var collection = database.GetCollection<User>();
        collection.Update(user);
        return user;
        
    }
}
