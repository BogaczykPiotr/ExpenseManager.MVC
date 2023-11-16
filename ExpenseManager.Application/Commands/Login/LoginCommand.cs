using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManager.Application.Commands.Login
{
    public class LoginCommand : IRequest<SignInResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
