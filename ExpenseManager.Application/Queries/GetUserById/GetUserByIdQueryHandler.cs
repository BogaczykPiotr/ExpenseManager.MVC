using AutoMapper;
using ExpenseManager.Application.DTOS;
using ExpenseManager.Domain.Interfaces;
using MediatR;

namespace ExpenseManager.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(IExpenseManagerRepository expenseManagerRepository,
            IMapper mapper)
        {
            _expenseManagerRepository = expenseManagerRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {

            var user = await _expenseManagerRepository.GetUserById(request.Id);

            var dto = _mapper.Map<UserDto>(user);

            return dto;
        }
    }
}
