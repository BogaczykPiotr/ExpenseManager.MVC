using ExpenseManager.Application.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.MVC.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;
        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> ManageUsers()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());

            return View(users);
        }
    }
}
