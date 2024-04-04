using ReportIoT.Models;

namespace ReportIoT.IService;

public interface IDataService
{
    Task<ReportData> GetDataNow();
}
