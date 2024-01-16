using ExpenseManager.Domain.Entities;
using ExpenseManager.Domain.Interfaces;
using ExpenseManager.Infrastructure.Persistence;
using ExpenseManager.Infrastructure.Repositories;
using ExpenseManager.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseManager.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ExpenseDbContext>(options
                => options.UseSqlServer(configuration.GetConnectionString("Database")));

            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.Stores.MaxLengthForKeys = 450;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ExpenseDbContext>();

            services.AddScoped<Seeder>();

            services.AddScoped<IExpenseManagerRepository, ExpenseManagerRepository>();

        }
    }
}
