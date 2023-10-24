using AutoMapper;
using ExpenseManager.Application.ApplicationUser;
using ExpenseManager.Domain.Entities;
using ExpenseManager.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.Commands.CreateSettings
{
    public class CreateSettingsCommandHandler : IRequestHandler<CreateSettingsCommand>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        public CreateSettingsCommandHandler(IMapper mapper, IExpenseManagerRepository expenseManagerRepository, IUserContext userContext)
        {
            _expenseManagerRepository = expenseManagerRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateSettingsCommand request, CancellationToken cancellationToken)
        {
            var settings = _mapper.Map<Domain.Entities.Setting>(request);

            settings.CreatedById = _userContext.GetCurrentUser().Id;

            await _expenseManagerRepository.CreateSettings(settings);



            return Unit.Value;
        }
    }
}
