using AutoMapper;
using ExpenseManager.Application.DTOS;
using ExpenseManager.Domain.Entities;
using ExpenseManager.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManager.Application.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<UserDto> _passwordHasher;
        public RegisterUserCommandHandler(
            IExpenseManagerRepository expenseManagerRepository,
            IMapper mapper,
            IPasswordHasher<UserDto> passwordHasher)
        {
            _expenseManagerRepository = expenseManagerRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {

            var userInfo = _mapper.Map<User>(request);

            userInfo.Password = _passwordHasher.HashPassword(request, userInfo.Password);

            await _expenseManagerRepository.CreateUserInformation(userInfo);;
            

            return Unit.Value;
        }
    }
}
