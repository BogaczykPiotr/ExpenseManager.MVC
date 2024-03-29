﻿using ExpenseManager.Application.DTOS;
using ExpenseManager.Application.UserService;
using ExpenseManager.Domain.Interfaces;
using MediatR;

namespace ExpenseManager.Application.Queries.GetStatValues
{
    public class GetStatValuesQueryHandler : IRequestHandler<GetStatValuesQuery, StatDto>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        private readonly IUserContext _userContext;
        public GetStatValuesQueryHandler(IExpenseManagerRepository expenseManagerRepository, IUserContext userContext)
        {
            _expenseManagerRepository = expenseManagerRepository;
            _userContext = userContext;
        }

        public async Task<StatDto> Handle(GetStatValuesQuery request, CancellationToken cancellationToken)
        {
            var userId = _userContext.GetCurrentUser()?.Id;
            var transfers = await _expenseManagerRepository.GetAllTransfers(userId);
            var savingGoal = await _expenseManagerRepository.GetLastSavingGoal();

            var statDto = new StatDto();
            statDto.AddTotalAmountStat(transfers, savingGoal);
            statDto.SavingGoal = savingGoal;

            return statDto;
        }
    }
}
