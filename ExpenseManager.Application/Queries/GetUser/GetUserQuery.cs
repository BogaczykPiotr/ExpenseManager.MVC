using ExpenseManager.Application.DTOS;
using MediatR;

namespace ExpenseManager.Application.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserDto>
    {

    }
}
