using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManager.Application.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, SignInResult>
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginCommandHandler(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<SignInResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, request.RememberMe, lockoutOnFailure: false);
            return result;
        }
    }
}
