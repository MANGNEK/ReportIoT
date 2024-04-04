using MongoDB.Driver;
using ReportIoT.Interface;

namespace ReportIoT.Dbconfig;

public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoDatabase _database;
    public MongoDbContext(string connection ,string databaseName)
    {
        var client = new MongoClient(connection);
        _database = client.GetDatabase(databaseName);
    }
    public IMongoCollection<T> GetCllection<T>(string CollectionName)
    {
        return _database.GetCollection<T>(CollectionName);
    }
}
