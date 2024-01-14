using ExpenseManager.Domain.Entities;
using MediatR;

namespace ExpenseManager.Application.Commands.EditUser
{
    public class EditUserCommand : ApplicationUser, IRequest
    {
    }
}
