using MongoDB.Driver;
using ReportIoT.Interface;
using ReportIoT.IService;
using ReportIoT.Models;

namespace ReportIoT.Service;

public class NotifycationServicecs : INotification
{
    private readonly IMongoCollection<NotifineModel> _notifications;
    public NotifycationServicecs(IMongoDbContext mongoDb) => _notifications = mongoDb.GetCllection<NotifineModel>("NotifineModel");
    public async Task<List<NotifineModel>> GetAll()
    {
        var list = await _notifications.Find(e => e.Id != null).ToListAsync();
        if (list.Count() > 0) return list;
        return new List<NotifineModel>();
    }
}
