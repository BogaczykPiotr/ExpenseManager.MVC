using AutoMapper;
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
    public class GetSavingGoalValuesQueryHandler : IRequestHandler<GetSavingGoalValuesQuery, SavingGoalDto>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        private readonly IMapper _mapper;
        public GetSavingGoalValuesQueryHandler(IExpenseManagerRepository expenseManagerRepository, IMapper mapper)
        {
            _expenseManagerRepository = expenseManagerRepository;
            _mapper = mapper;
        }
        public async Task<SavingGoalDto> Handle(GetSavingGoalValuesQuery request, CancellationToken cancellationToken)
        {
            var lastSavingGoal = await _expenseManagerRepository.GetLastSavingGoal();
            var dtos = _mapper.Map<SavingGoalDto>(lastSavingGoal);

            return dtos;
        }
    }
}
