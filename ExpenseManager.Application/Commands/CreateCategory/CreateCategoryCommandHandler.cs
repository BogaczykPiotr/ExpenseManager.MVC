﻿using AutoMapper;
using ExpenseManager.Application.UserService;
using ExpenseManager.Domain.Entities;
using ExpenseManager.Domain.Interfaces;
using MediatR;


namespace ExpenseManager.Application.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    { 
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        public CreateCategoryCommandHandler(IExpenseManagerRepository expenseManagerRepository, IMapper mapper, IUserContext userContext)
        {
            _expenseManagerRepository = expenseManagerRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);

            category.CreatedById = _userContext.GetCurrentUser().Id;

            await _expenseManagerRepository.CreateCategory(category);

            

            return Unit.Value;
        }
    }
}
