﻿using ExpenseManager.Application.ApplicationUser;
using ExpenseManager.Application.Commands.CreateTransfer;
using ExpenseManager.Application.Mappings;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseManager.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();

            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddMediatR(typeof(CreateTransferCommand));

        }
    }
}
