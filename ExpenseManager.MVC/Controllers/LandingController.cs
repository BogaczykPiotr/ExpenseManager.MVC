using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.MVC.Controllers
{
    [AllowAnonymous]
    public class LandingController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
