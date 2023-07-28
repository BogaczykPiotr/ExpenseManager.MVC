using ExpenseManager.Application.DTOS;
using MediatR;

namespace ExpenseManager.Application.Queries.GetAllTransfers
{
    public class GetAllTransfersQuery : IRequest<IEnumerable<TransferDto>>
    {
    }
}
