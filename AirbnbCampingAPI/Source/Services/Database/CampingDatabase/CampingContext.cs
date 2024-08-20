using AirbnbCamping.Core.Model;
using LiteDB;

namespace AirbnbCamping.Services.Database.CampingServices.Database;

public class CampingContext : ICampingContext
{
    private readonly string _connectionString = @"Filename=campingdatabase.db;connection=shared";

    public void AddCamping(Camping camping)
    {
        using var database = new LiteServices.Database(_connectionString);
        database.GetCollection<Camping>("Camping").Insert(camping);
    }

    public ICore.Enumerable<Camping> GetAll()
    {
        using var database = new LiteServices.Database(_connectionString);
        return database.GetCollection<Camping>("Camping").FindAll();
    }

    public Camping GetById(int id)
    {
        using var database = new LiteServices.Database(_connectionString);
        var collection = database.GetCollection<Camping>("Camping");
        return collection.FindById(id);
    }

    public Camping UpdateCamping(Camping camping)
    {
        using var database = new LiteServices.Database(_connectionString);
        var collection = database.GetCollection<Camping>("Camping");
        collection.Update(camping);
        return camping;
    }
}
