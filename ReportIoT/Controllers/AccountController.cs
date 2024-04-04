using Microsoft.AspNetCore.Mvc;
using ReportIoT.IService;

namespace ReportIoT.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccount _account;
        public AccountController( IAccount account) {
        _account = account;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<bool> CheckAcc(string acc, string pass)
        {
            return await _account.GetMe(acc, pass);   
        }
    }
}
