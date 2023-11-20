using AutoMapper;
using ExpenseManager.Domain.Entities;
using ExpenseManager.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.Commands.AddUserInformation
{
    public class AddUserInformationCommandHandler : IRequestHandler<AddUserInformationCommand>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        private readonly IMapper _mapper;
        public AddUserInformationCommandHandler(IExpenseManagerRepository expenseManagerRepository, IMapper mapper)
        {
            _expenseManagerRepository = expenseManagerRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(AddUserInformationCommand request, CancellationToken cancellationToken)
        {
            var userInfo = _mapper.Map<User>(request);

            await _expenseManagerRepository.CreateUserInformation(userInfo);

            return Unit.Value;
        }
    }
}
