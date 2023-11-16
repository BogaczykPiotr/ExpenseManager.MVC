using AutoMapper;
using ExpenseManager.Application.DTOS;
using ExpenseManager.Application.Queries.GetCategoryById;
using ExpenseManager.Domain.Interfaces;
using MediatR;

namespace ExpenseManager.Application.Queries.GetCategoryByName
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        private readonly IMapper _mapper;
        public GetCategoryByIdQueryHandler(IExpenseManagerRepository expenseManagerRepository, IMapper mapper)
        {
            _expenseManagerRepository = expenseManagerRepository;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _expenseManagerRepository.GetByCategoryId(request.Id);

            var dto = _mapper.Map<CategoryDto>(category);

            return dto;

        }
    }
}
