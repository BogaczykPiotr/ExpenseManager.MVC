using ExpenseManager.Application.DTOS;
using MediatR;

namespace ExpenseManager.Application.Commands.DeleteUser
{
    public class DeleteUserCommand : UserDto, IRequest
    {
        public string Id { get; set; }
        public DeleteUserCommand(string id)
        {
            Id = id;
        }
    }
}
