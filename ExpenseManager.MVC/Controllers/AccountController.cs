using ExpenseManager.Application.Commands.LoginUser;
using ExpenseManager.Application.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.MVC.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            try
            {
               
                var token = await _mediator.Send(command);

                
                return RedirectToAction("Dashboard", "ExpenseManager", new { token });
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "Błąd logowania. Sprawdź swoje dane.");
                return View(command);
            }
        }



        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}
