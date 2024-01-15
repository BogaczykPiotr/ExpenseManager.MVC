using ExpenseManager.Domain.Interfaces;
using MediatR;

namespace ExpenseManager.Application.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequest<DeleteUserCommand>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        public DeleteUserCommandHandler(IExpenseManagerRepository expenseManagerRepository)
        {
            _expenseManagerRepository = expenseManagerRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _expenseManagerRepository.GetUserById(request.Id);
            await _expenseManagerRepository.DeleteUser(user);
            await _expenseManagerRepository.Commit();
            return Unit.Value;
        }
    }
}
