using ExpenseManager.Application.DTOS;
using MediatR;

namespace ExpenseManager.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
    {}
}
