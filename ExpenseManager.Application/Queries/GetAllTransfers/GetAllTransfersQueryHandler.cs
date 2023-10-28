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

namespace ExpenseManager.Application.Queries.GetAllTransfers
{
public class GetAllTransfersQueryHandler : IRequestHandler<GetAllTransfersQuery, IEnumerable<TransferDto>>
    {
        private readonly IMapper _mapper;
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        private readonly IUserContext _userContext;
        public GetAllTransfersQueryHandler(IMapper mapper, IExpenseManagerRepository expenseManagerRepository, IUserContext userContext)
        {
            _mapper = mapper;
            _expenseManagerRepository = expenseManagerRepository;
            _userContext = userContext;
        }
        public async Task<IEnumerable<TransferDto>> Handle(GetAllTransfersQuery request, CancellationToken cancellationToken)
        {
            var Transfers = await _expenseManagerRepository.GetAllTransfers(_userContext.GetCurrentUser().Id);
            var Dtos = _mapper.Map<IEnumerable<TransferDto>>(Transfers);
            return Dtos;
        }
    }
}
