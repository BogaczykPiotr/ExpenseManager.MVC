using AutoMapper;
using ExpenseManager.Application.Commands.DeleteCategory;
using ExpenseManager.Application.Commands.DeleteUser;
using ExpenseManager.Application.Commands.EditUser;
using ExpenseManager.Application.Queries.GetAllUsers;
using ExpenseManager.Application.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.MVC.Controllers
{
    [Authorize]
    [ValidateAntiForgeryToken]
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public AdminController(IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }
        public async Task<IActionResult> ManageUsers()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());

            return View(users);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _mediator.Send(new DeleteUserCommand(id));

            return RedirectToAction(nameof(ManageUsers));
        }

        [Route("Admin/{id}/EditUser")]
        public async Task<IActionResult> EditUser(string id)
        {
            var dto = await _mediator.Send(new GetUserByIdQuery(id));
            EditUserCommand model = _mapper.Map<EditUserCommand>(dto);
            return View(model);
        }

        [HttpPost]
        [Route("Admin/{id}/EditUser")]
        public async Task<IActionResult> EditUser(EditUserCommand command)
        {
            await _mediator.Send(command);

            return RedirectToAction(nameof(ManageUsers));
        }



    }
}
