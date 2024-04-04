using ReportIoT.Models;

namespace ReportIoT.IService;

public interface IDataDay
{
    Task<DataDayNowModel> GetData();
}
