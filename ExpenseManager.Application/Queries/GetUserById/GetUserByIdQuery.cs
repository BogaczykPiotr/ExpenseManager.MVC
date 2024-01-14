using ExpenseManager.Application.DTOS;
using MediatR;

namespace ExpenseManager.Application.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public string Id { get; set; }
        public GetUserByIdQuery(string id)
        {
            Id = id;
        }
    }
}
