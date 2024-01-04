using ExpenseManager.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.MVC.Controllers
{
    [AllowAnonymous]
    public class LandingController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        public LandingController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Dashboard", "ExpenseManager");
            }

            return View();
        }
    }
}
