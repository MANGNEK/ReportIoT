using Microsoft.AspNetCore.Mvc;
using ReportIoT.IService;
using ReportIoT.Models;
using System.Diagnostics;

namespace ReportIoT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataService _dataService;
        private readonly IDataDay dataDay;

        public HomeController(ILogger<HomeController> logger , IDataService service, IDataDay dataDay)
        {
            _logger = logger;
            _dataService = service;
            this.dataDay = dataDay;
        }

        public async Task<IActionResult> Index()
        {
            var dataApi = await dataDay.GetData();
            var dataSensor =await _dataService.GetDataNow();
            var data = new
            {
                dataApi = dataApi,
                dataSensor = dataSensor
            };
            return View(data);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<ReportData> Data()
        {
            var data = await _dataService.GetDataNow();
            return data;
        }
    }
}
