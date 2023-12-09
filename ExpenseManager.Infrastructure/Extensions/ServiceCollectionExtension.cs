using ExpenseManager.Application.Authentication;
using ExpenseManager.Domain.Entities;
using ExpenseManager.Domain.Interfaces;
using ExpenseManager.Infrastructure.Persistence;
using ExpenseManager.Infrastructure.Repositories;
using ExpenseManager.Infrastructure.Seeders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ExpenseManager.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ExpenseDbContext>(options
                => options.UseSqlServer(configuration.GetConnectionString("Database")));

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.Stores.MaxLengthForKeys = 450;
            })
                .AddEntityFrameworkStores<ExpenseDbContext>();


            services.AddScoped<Seeder>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            services.AddScoped<IExpenseManagerRepository, ExpenseManagerRepository>();

            var authenticationService = new AuthenticationSettings();
            configuration.GetSection("Authentication").Bind(authenticationService);

            services.AddSingleton<AuthenticationSettings>(provider => authenticationService);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Bearer";
                options.DefaultScheme = "Bearer";
                options.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationService.JwtIssuer,
                    ValidAudience = authenticationService.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationService.JwtKey)),
                };
            });

        }
    }
}
