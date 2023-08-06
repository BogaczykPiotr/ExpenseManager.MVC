using AutoMapper;
using ExpenseManager.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.Commands.CreateTransfer
{
    public class CreateTransferCommandHandler : IRequestHandler<CreateTransferCommand>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        private readonly IMapper _mapper;
        public CreateTransferCommandHandler(IMapper mapper, IExpenseManagerRepository expenseManagerRepository)
        {
            _expenseManagerRepository = expenseManagerRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            var transfer = _mapper.Map<Domain.Entities.Transfer>(request);
            await _expenseManagerRepository.CreateTransfer(transfer);

            return Unit.Value;
        }
    }
}
