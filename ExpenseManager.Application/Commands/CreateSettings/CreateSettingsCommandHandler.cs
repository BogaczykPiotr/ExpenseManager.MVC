using AutoMapper;
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
        public CreateSettingsCommandHandler(IMapper mapper, IExpenseManagerRepository expenseManagerRepository)
        {
            _expenseManagerRepository = expenseManagerRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateSettingsCommand request, CancellationToken cancellationToken)
        {
            var settings = _mapper.Map<Domain.Entities.Setting>(request);
            await _expenseManagerRepository.CreateSettings(settings);

            return Unit.Value;
        }
    }
}
