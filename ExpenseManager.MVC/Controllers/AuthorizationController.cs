using ExpenseManager.Application.Commands.Login;
using ExpenseManager.Application.Queries.GetAllTransfers;
using ExpenseManager.Application.Queries.GetSettingValues;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.MVC.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IMediator _mediator;
        public AuthorizationController(IMediator mediator, SignInManager<IdentityUser> singInManager)
        {
            _mediator = mediator;

        }
        public async Task<IActionResult> Login()
        {
            await ViewLayoutData();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginCommand command, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(command);
                if (result.Succeeded)
                {
                    return Ok(new { success = true, returnUrl });
                }
                return BadRequest(new { success = false, errors = "Invalid login attempt." });
            }
            return BadRequest(new { success = false, errors = "Invalid model state." });
        }


        protected async Task ViewLayoutData()
        {
            ViewData["TransferDtos"] = await _mediator.Send(new GetAllTransfersQuery());
            ViewData["SettingsDto"] = await _mediator.Send(new GetSettingValuesQuery());
        }
    }
}
