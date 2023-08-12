﻿using ExpenseManager.Application.DTOS;
using ExpenseManager.Domain.Interfaces;
using MediatR;

namespace ExpenseManager.Application.Queries.GetStatValues
{
    public class GetStatValuesQueryHandler : IRequestHandler<GetStatValuesQuery, StatDto>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;

        public GetStatValuesQueryHandler(IExpenseManagerRepository expenseManagerRepository)
        {
            _expenseManagerRepository = expenseManagerRepository;
        }

        public async Task<StatDto> Handle(GetStatValuesQuery request, CancellationToken cancellationToken)
        {
            var transfers = await _expenseManagerRepository.GetAllTransfers();
            var savingGoal = await _expenseManagerRepository.GetLastSavingGoal();

            var statDto = new StatDto();
            statDto.AddTotalAmountStat(transfers, savingGoal);
            statDto.SavingGoal = savingGoal;

            return statDto;
        }
    }
}
