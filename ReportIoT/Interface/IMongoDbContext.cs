using MongoDB.Driver;
namespace ReportIoT.Interface;

public interface IMongoDbContext
{
    IMongoCollection<T> GetCllection<T>(string CollectionName);
}
