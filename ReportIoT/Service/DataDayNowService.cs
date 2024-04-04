using MongoDB.Driver;
using ReportIoT.Interface;
using ReportIoT.IService;
using ReportIoT.Models;

namespace ReportIoT.Service;

public class DataDayNowService : IDataDay
{
    private IMongoCollection<DataDayNowModel> _dataDayNow;
    public DataDayNowService(IMongoDbContext dbContext) {
        _dataDayNow = dbContext.GetCllection<DataDayNowModel>("DataDayNowModel");
    }
    public async Task<DataDayNowModel> GetData()
    {
        var data = await _dataDayNow.Find(e => e.Id != null).FirstOrDefaultAsync();
        if (data == null) return new DataDayNowModel {};
        return data;
    }
}
