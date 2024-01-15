using ExpenseManager.Domain.Interfaces;
using MediatR;

namespace ExpenseManager.Application.Commands.EditUser
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand>
    {
        IExpenseManagerRepository _expenseManagerRepository;
        public EditUserCommandHandler(IExpenseManagerRepository expenseManagerRepository)
        {
            _expenseManagerRepository = expenseManagerRepository;
        }
        public async Task<Unit> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _expenseManagerRepository.GetUserById(request.Id!);

            user.UserName = request.UserName!;
            user.Email = request.Email!;
            user.PhoneNumber = request.PhoneNumber!;
            user.Address = request.Address!;
            user.Country = request.Country!;
            user.LockoutEnabled = request.LockoutEnabled;
            user.IsActive = request.IsActive;

            await _expenseManagerRepository.Commit();

            return Unit.Value;
            
        }
    }
}
