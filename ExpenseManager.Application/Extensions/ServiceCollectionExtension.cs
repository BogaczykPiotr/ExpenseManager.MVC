using ExpenseManager.Application.ApplicationUser;
using ExpenseManager.Application.Commands.CreateTransfer;
using ExpenseManager.Application.DTOS;
using ExpenseManager.Application.Mappings;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseManager.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();

            services.AddScoped<IPasswordHasher<UserDto>, PasswordHasher<UserDto>>();

            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddMediatR(typeof(CreateTransferCommand));

        }
    }
}
