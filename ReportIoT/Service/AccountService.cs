using Mapster;
using MongoDB.Driver;
using ReportIoT.DefineData;
using ReportIoT.Interface;
using ReportIoT.IService;
using ReportIoT.Models;
namespace ReportIoT.Service;

public class AccountService : IAccount
{
    private readonly IMongoCollection<Account> _accounts;
    public AccountService(IMongoDbContext context)
    {
        _accounts = context.GetCllection<Account>("Account");
    }
   public async Task<List<AccountReponse>> GetAllAsync()
    {
        var data = await _accounts.Find(e => e.Status == "Active").ToListAsync();
        var responseList = data.Adapt<List<AccountReponse>>();
        return responseList;
    }

    public async Task<bool> GetMe(string User, string Pass)
    {
        var data = await _accounts.Find(e => e.User == User).FirstOrDefaultAsync();
        if(data == null) return false;
        if(data.Password != Pass) return false;
        return true;
    }

}
