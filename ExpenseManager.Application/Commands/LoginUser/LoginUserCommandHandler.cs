using AutoMapper;
using ExpenseManager.Application.Authentication;
using ExpenseManager.Application.DTOS;
using ExpenseManager.Domain.Entities;
using ExpenseManager.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IExpenseManagerRepository _expenseManagerRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<UserDto> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        public LoginUserCommandHandler(IExpenseManagerRepository expenseManagerRepository, 
            IMapper mapper,
            IPasswordHasher<UserDto> passwordHasher,
            AuthenticationSettings authenticationSettings,
            SignInManager<User> signInManager)
        {
            _expenseManagerRepository = expenseManagerRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        async Task<string> IRequestHandler<LoginUserCommand, string>.Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = _expenseManagerRepository.GetUserByEmail(request.Email);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var userInfo = _mapper.Map<User>(user);
            var result = _passwordHasher.VerifyHashedPassword(request, userInfo.Password, request.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new Exception("Invalid password");
            }
    
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, userInfo.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{userInfo.Name} {userInfo.LastName}"),
                new Claim(ClaimTypes.Role, $"{userInfo.Role.Name}"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();



            return tokenHandler.WriteToken(token);
        }
    }
}
