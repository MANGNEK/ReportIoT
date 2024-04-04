using ReportIoT.Interface;
using ReportIoT.IService;
using ReportIoT.Service;

namespace ReportIoT.Dbconfig;

public static class DataBaseConfig
{
    public static void ConfigDataBase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IMongoDbContext>(provide =>
        {
            var connection = configuration.GetValue<string>("MongoConnection:ConnectionString");
            var nameDataBase = configuration.GetValue<string>("MongoConnection:DatabaseName");
            return new MongoDbContext(connection!, nameDataBase!);
        });
        services.AddScoped<IDataService, ReportDataService>();
        services.AddScoped<IDataDay, DataDayNowService>();
        services.AddScoped<IAccount,  AccountService>();
    }
}
