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

namespace ExpenseManager.Application.Queries.GetSettingValues
{
    public class GetSettingValuesQueryHandler : IRequestHandler<GetSettingValuesQuery, SettingDto>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        public GetSettingValuesQueryHandler(IExpenseManagerRepository expenseManagerRepository, IMapper mapper, IUserContext userContext)
        {
            _expenseManagerRepository = expenseManagerRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<SettingDto> Handle(GetSettingValuesQuery request, CancellationToken cancellationToken)
        {
            var userId = _userContext.GetCurrentUser()?.Id;
            if (userId == null)
            {
                return null;
            }
            var settings = await _expenseManagerRepository.GetSettings(userId);
            var dto = _mapper.Map<SettingDto>(settings);
            return dto;
        }
    }
}
