using ExpenseManager.Application.DTOS;
using MediatR;

namespace ExpenseManager.Application.Commands.DeleteTransfer
{
    public class DeleteTransferCommand : TransferDto, IRequest
    {
    }
}
