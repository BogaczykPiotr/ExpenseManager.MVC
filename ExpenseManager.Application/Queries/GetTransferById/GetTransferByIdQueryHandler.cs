using AutoMapper;
using ExpenseManager.Application.DTOS;
using ExpenseManager.Domain.Interfaces;
using MediatR;

namespace ExpenseManager.Application.Queries.GetTransferById
{
    public class GetTransferByIdQueryHandler : IRequestHandler<GetTransferByIdQuery, TransferDto>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        private readonly IMapper _mapper;
        public GetTransferByIdQueryHandler(IExpenseManagerRepository expenseManagerRepository, IMapper mapper)
        {
            _expenseManagerRepository = expenseManagerRepository;
            _mapper = mapper;
        }
        public async Task<TransferDto> Handle(GetTransferByIdQuery request, CancellationToken cancellationToken)
        {
            var transfer = await _expenseManagerRepository.GetByTransferId(request.Id);
            var dto = _mapper.Map<TransferDto>(transfer);

            return dto;
        }
    }
}
