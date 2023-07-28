using AutoMapper;
using ExpenseManager.Application.DTOS;
using ExpenseManager.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.Queries.GetAllTransfers
{
public class GetAllTransfersQueryHandler : IRequestHandler<GetAllTransfersQuery, IEnumerable<TransferDto>>
    {
        private readonly IMapper _mapper;
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        public GetAllTransfersQueryHandler(IMapper mapper, IExpenseManagerRepository expenseManagerRepository)
        {
            _mapper = mapper;
            _expenseManagerRepository = expenseManagerRepository;
        }
        public async Task<IEnumerable<TransferDto>> Handle(GetAllTransfersQuery request, CancellationToken cancellationToken)
        {
            var Transfers = await _expenseManagerRepository.GetAllTransfers();
            var Dtos = _mapper.Map<IEnumerable<TransferDto>>(Transfers);

            return Dtos;
        }
    }
}
