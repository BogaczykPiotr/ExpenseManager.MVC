using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.MVC.Controllers
{
    public class LandingController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
