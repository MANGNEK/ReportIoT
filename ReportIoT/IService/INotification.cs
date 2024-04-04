using ReportIoT.Models;

namespace ReportIoT.IService;

public interface INotification
{
    Task<List<NotifineModel>> GetAll();
}
