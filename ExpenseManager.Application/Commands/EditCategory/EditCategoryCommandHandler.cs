using ExpenseManager.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.Commands.EditCategory
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        public EditCategoryCommandHandler(IExpenseManagerRepository expenseManagerRepository)
        {
            _expenseManagerRepository = expenseManagerRepository;
        }
        public async Task<Unit> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _expenseManagerRepository.GetByCategoryId(request.Id!);

            category.Name = request.Name;

            await _expenseManagerRepository.Commit();
            return Unit.Value;
        }
    }
}
