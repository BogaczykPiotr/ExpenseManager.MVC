using ExpenseManager.Application.DTOS;
using MediatR;

namespace ExpenseManager.Application.Commands.CreateTransfer
{
    public class CreateTransferCommand : TransferDto, IRequest
    {
    }
}
