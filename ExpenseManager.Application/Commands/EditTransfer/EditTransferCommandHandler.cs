using AutoMapper;
using ExpenseManager.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.Commands.EditTransfer
{
    public class EditTransferCommandHandler : IRequestHandler<EditTransferCommand>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        public EditTransferCommandHandler(IExpenseManagerRepository expenseManagerRepository)
        {
            _expenseManagerRepository = expenseManagerRepository;
        }
        public async Task<Unit> Handle(EditTransferCommand request, CancellationToken cancellationToken)
        {
            var transfer = await _expenseManagerRepository.GetByTransferId(request.Id!);

            transfer.Value = request.Value!;
            transfer.Category = request.Category!;
            transfer.Description = request.Description!;
            transfer.CreatedAt = request.CreatedAt!;

            await _expenseManagerRepository.Commit();
            return Unit.Value;
        }
    }
}
