using AutoMapper;
using ExpenseManager.Domain.Interfaces;
using MediatR;

namespace ExpenseManager.Application.Commands.DeleteTransfer
{
    public class DeleteTransferCommandHandler : IRequestHandler<DeleteTransferCommand>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        public DeleteTransferCommandHandler(IExpenseManagerRepository expenseManagerRepository)
        {
            _expenseManagerRepository = expenseManagerRepository;
        }
        public async Task<Unit> Handle(DeleteTransferCommand request, CancellationToken cancellationToken)
        {
            var transfer = await _expenseManagerRepository.GetByTransferId(request.Id);
            await _expenseManagerRepository.DeleteTransfer(transfer);
            await _expenseManagerRepository.Commit();

            return Unit.Value;

        }
    }
}
