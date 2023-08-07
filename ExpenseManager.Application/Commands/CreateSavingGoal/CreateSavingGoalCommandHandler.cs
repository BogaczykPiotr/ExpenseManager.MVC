using AutoMapper;
using ExpenseManager.Domain.Interfaces;
using MediatR;

namespace ExpenseManager.Application.Commands.CreateSavingGoal
{
    public class CreateSavingGoalCommandHandler : IRequestHandler<CreateSavingGoalCommand>
    {
        private readonly IMapper _mapper;
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        public CreateSavingGoalCommandHandler(IMapper mapper, IExpenseManagerRepository expenseManagerRepository)
        {
            _mapper = mapper;
            _expenseManagerRepository = expenseManagerRepository;
        }
        public async Task<Unit> Handle(CreateSavingGoalCommand request, CancellationToken cancellationToken)
        {
            var SavingGoal = _mapper.Map<Domain.Entities.SavingGoal>(request);
            await _expenseManagerRepository.CreateSavingGoal(SavingGoal);

            return Unit.Value;
        }
    }
}
