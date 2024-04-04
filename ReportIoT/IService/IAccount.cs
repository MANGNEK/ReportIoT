using ReportIoT.DefineData;

namespace ReportIoT.IService;

public interface IAccount
{
    Task<List<AccountReponse>> GetAllAsync();
    Task<bool> GetMe(string User, string Pass);
}
