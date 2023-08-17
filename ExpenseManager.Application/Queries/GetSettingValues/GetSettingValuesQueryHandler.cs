using AutoMapper;
using ExpenseManager.Application.DTOS;
using ExpenseManager.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.Queries.GetSettingValues
{
    public class GetSettingValuesQueryHandler : IRequestHandler<GetSettingValuesQuery, SettingDto>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        private readonly IMapper _mapper;
        public GetSettingValuesQueryHandler(IExpenseManagerRepository expenseManagerRepository, IMapper mapper)
        {
            _expenseManagerRepository = expenseManagerRepository;
            _mapper = mapper;
        }
        public async Task<SettingDto> Handle(GetSettingValuesQuery request, CancellationToken cancellationToken)
        {
            var settings = await _expenseManagerRepository.GetSettings();
            var dto = _mapper.Map<SettingDto>(settings);
            return dto;
        }
    }
}
