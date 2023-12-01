using AutoMapper;
using ExpenseManager.Domain.Entities;
using ExpenseManager.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        public LoginUserCommandHandler(IExpenseManagerRepository expenseManagerRepository, 
            IMapper mapper,
            IPasswordHasher<User> passwordHasher)
        {
            _expenseManagerRepository = expenseManagerRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public Task<Unit> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = _expenseManagerRepository.GetUserByEmail(request.Email);
            if(user == null)
            {
                throw new Exception();
            }
            var userDto = _mapper.Map<User>(user);
            var result = _passwordHasher.VerifyHashedPassword(userDto, userDto.Password, request.Password);
            if(result == PasswordVerificationResult.Failed)
            {
                throw new Exception();
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, userDto.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{userDto.Name} {userDto.LastName}"),
                new Claim(ClaimTypes.Role, $"{userDto.Role.Name}"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes()); // to continue


        }
    }
}
