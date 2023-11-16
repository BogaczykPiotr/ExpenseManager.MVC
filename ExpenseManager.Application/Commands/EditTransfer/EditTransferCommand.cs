using ExpenseManager.Application.DTOS;
using MediatR;

namespace ExpenseManager.Application.Commands.EditTransfer
{
    public class EditTransferCommand : TransferDto, IRequest
    {
    }
}
