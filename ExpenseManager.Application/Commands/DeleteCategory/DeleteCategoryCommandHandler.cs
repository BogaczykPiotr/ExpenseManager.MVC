using ExpenseManager.Domain.Interfaces;
using MediatR;

namespace ExpenseManager.Application.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        public DeleteCategoryCommandHandler(IExpenseManagerRepository expenseManagerRepository)
        {
            _expenseManagerRepository = expenseManagerRepository;
        }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _expenseManagerRepository.GetByCategoryId(request.Id);
            await _expenseManagerRepository.DeleteCategory(category);
            await _expenseManagerRepository.Commit();

            return Unit.Value;
        }
    }
}
