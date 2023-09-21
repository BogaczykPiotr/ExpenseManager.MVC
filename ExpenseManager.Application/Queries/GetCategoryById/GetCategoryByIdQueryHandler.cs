using AutoMapper;
using ExpenseManager.Application.DTOS;
using ExpenseManager.Application.Queries.GetCategoryById;
using ExpenseManager.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.Queries.GetCategoryByName
{
    public class GetCategoryByNameQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        private readonly IMapper _mapper;
        public GetCategoryByNameQueryHandler(IExpenseManagerRepository expenseManagerRepository, IMapper mapper)
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
