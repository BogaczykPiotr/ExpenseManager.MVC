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
        public Task<Unit> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _expenseManagerRepository.GetByCategoryId(request.Id!);

            // to fix
        }
    }
}
