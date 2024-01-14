using AutoMapper;
using ExpenseManager.Application.UserService;
using ExpenseManager.Domain.Interfaces;
using MediatR;

namespace ExpenseManager.Application.Commands.CreateSavingGoal
{
    public class CreateSavingGoalCommandHandler : IRequestHandler<CreateSavingGoalCommand>
    {
        private readonly IMapper _mapper;
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        private readonly IUserContext _userContext;
        public CreateSavingGoalCommandHandler(IMapper mapper, IExpenseManagerRepository expenseManagerRepository, IUserContext userContext)
        {
            _mapper = mapper;
            _expenseManagerRepository = expenseManagerRepository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateSavingGoalCommand request, CancellationToken cancellationToken)
        {
            var SavingGoal = _mapper.Map<Domain.Entities.SavingGoal>(request);

            SavingGoal.CreatedById = _userContext.GetCurrentUser().Id;

            await _expenseManagerRepository.CreateSavingGoal(SavingGoal);



            return Unit.Value;
        }
    }
}
