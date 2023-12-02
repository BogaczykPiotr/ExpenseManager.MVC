using ExpenseManager.Application.ApplicationUser;
using ExpenseManager.Application.Commands.CreateTransfer;
using ExpenseManager.Application.DTOS;
using ExpenseManager.Application.Mappings;
using ExpenseManager.Domain.Entities;
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

            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddMediatR(typeof(CreateTransferCommand));

        }
    }
}
