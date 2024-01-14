using AutoMapper;
using ExpenseManager.Application.UserService;
using ExpenseManager.Domain.Interfaces;
using MediatR;

namespace ExpenseManager.Application.Commands.CreateTransfer
{
    public class CreateTransferCommandHandler : IRequestHandler<CreateTransferCommand>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        public CreateTransferCommandHandler(IMapper mapper, IExpenseManagerRepository expenseManagerRepository, IUserContext userContext)
        {
            _expenseManagerRepository = expenseManagerRepository;
            _mapper = mapper;
            _userContext = userContext;
            
        }
        public async Task<Unit> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            var transfer = _mapper.Map<Domain.Entities.Transfer>(request);

            transfer.CreatedById = _userContext.GetCurrentUser().Id;

            await _expenseManagerRepository.CreateTransfer(transfer);



            return Unit.Value;
        }
    }
}
