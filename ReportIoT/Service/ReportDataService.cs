using MongoDB.Driver;
using ReportIoT.Interface;
using ReportIoT.IService;
using ReportIoT.Models;

namespace ReportIoT.Service;

public class ReportDataService :IDataService
{
    private readonly IMongoCollection<ReportData> _dataReport;
    public ReportDataService(IMongoDbContext dbContext)
    {
        _dataReport = dbContext.GetCllection<ReportData>("ReportData");
    }

    public async Task<ReportData> GetDataNow()
    {
        //var filter = Builders<Data>.Filter.Empty;
        var data = await _dataReport.Find(e => e.Temperture != "").FirstOrDefaultAsync();
        if(data == null) return new ReportData { };
        return  data;
    }
}
