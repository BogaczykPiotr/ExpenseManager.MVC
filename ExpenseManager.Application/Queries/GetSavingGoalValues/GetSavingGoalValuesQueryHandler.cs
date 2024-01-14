using AutoMapper;
using ExpenseManager.Application.DTOS;
using ExpenseManager.Application.UserService;
using ExpenseManager.Domain.Interfaces;
using MediatR;

namespace ExpenseManager.Application.Queries.GetSavingGoalValues
{
    public class GetSavingGoalValuesQueryHandler : IRequestHandler<GetSavingGoalValuesQuery, IEnumerable<SavingGoalDto>>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public GetSavingGoalValuesQueryHandler(IExpenseManagerRepository expenseManagerRepository, IMapper mapper, IUserContext userContext)
        {
            _expenseManagerRepository = expenseManagerRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<IEnumerable<SavingGoalDto>> Handle(GetSavingGoalValuesQuery request, CancellationToken cancellationToken)
        {
            var userId = _userContext.GetCurrentUser()?.Id;
            if (userId == null)
            {
                return Enumerable.Empty<SavingGoalDto>();
            }
            var lastSavingGoal = await _expenseManagerRepository.GetAllSavingGoals(userId);
            var dtos = _mapper.Map<IEnumerable<SavingGoalDto>>(lastSavingGoal);

            return dtos;
        }
    }
}