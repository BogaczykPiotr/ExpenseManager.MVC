using ExpenseManager.Application.DTOS;
using MediatR;

namespace ExpenseManager.Application.Queries.GetTransferById
{
    public class GetTransferByIdQuery : IRequest<TransferDto>
    {
        public int Id { get; set; }
        public GetTransferByIdQuery(int id)
        {
            Id = id;
        }
    }
}
