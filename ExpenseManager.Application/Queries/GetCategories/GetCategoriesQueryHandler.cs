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

namespace ExpenseManager.Application.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        public GetCategoriesQueryHandler(IExpenseManagerRepository expenseManagerRepository, IMapper mapper, IUserContext userContext)
        {
            _expenseManagerRepository = expenseManagerRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var userId = _userContext.GetCurrentUser().Id;
            var categories = await _expenseManagerRepository.GetAllCategories(userId);
            var dtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return dtos;
        }
    }
}
