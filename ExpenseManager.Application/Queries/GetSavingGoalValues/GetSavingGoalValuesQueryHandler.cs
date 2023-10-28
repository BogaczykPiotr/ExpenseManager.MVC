using AutoMapper;
using ExpenseManager.Application.ApplicationUser;
using ExpenseManager.Application.DTOS;
using ExpenseManager.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var lastSavingGoal = await _expenseManagerRepository.GetAllSavingGoals(_userContext.GetCurrentUser().Id);
            var dtos = _mapper.Map<IEnumerable<SavingGoalDto>>(lastSavingGoal);

            return dtos;
        }
    }
}