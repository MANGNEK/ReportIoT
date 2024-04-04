using Microsoft.AspNetCore.Mvc;
using ReportIoT.IService;

namespace ReportIoT.Controllers
{
    public class NotifyController : Controller
    {
        private readonly INotification _notification;
        public NotifyController(INotification notification) { _notification = notification; }
        public async Task<IActionResult> Index()
        {
            var data = await _notification.GetAll();
            return View(data);
        }
    }
}
