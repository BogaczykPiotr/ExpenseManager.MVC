using ExpenseManager.Domain.Entities;
using ExpenseManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManager.Infrastructure.Seeders
{
    public class Seeder
    {
        private readonly ExpenseDbContext _dbContext;
        public Seeder(ExpenseDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Settings.Any())
                {
                    var settings = new Setting()
                    {
                        Language = "english",
                        Currency = "$",
                        NumberOfDisplayedActions = 3
                    };

                    _dbContext.Add(settings);
                    await _dbContext.SaveChangesAsync();

                }
                if (!_dbContext.SavingGoals.Any())
                {
                    var savingGoal = new SavingGoal()
                    {
                        CreatedAt = DateTime.Now,
                        Goal = 0
                    };

                    _dbContext.SavingGoals.Add(savingGoal);
                    await _dbContext.SaveChangesAsync();
                }
                if (!_dbContext.Users.Any())
                {
                    var user = new ApplicationUser()
                    {
                        UserName = "user",
                        NormalizedUserName = "USER",
                        Email = "user@user",
                        NormalizedEmail = "USER@USER",
                        Address = "user",
                        CreatedAt = DateTime.Now,
                        Country = "Poland",
                        EmailConfirmed = true,
                        IsActive = true,
                        LastLogin = DateTime.Now,
                        LastPasswordChange = DateTime.Now
                    };
                    PasswordHasher <ApplicationUser> userhash = new PasswordHasher<ApplicationUser>();

                    user.PasswordHash = userhash.HashPassword(user, "t]rep)I8+UWM&IcS!QU^");

                    await _dbContext.Users.AddAsync(user);

                    var admin = new ApplicationUser()
                    {
                        UserName = "admin",
                        Email = "admin@admin",
                        NormalizedEmail = "ADMIN@ADMIN",
                        NormalizedUserName = "ADMIN",
                        Address = "admin",
                        CreatedAt = DateTime.Now,
                        Country = "Poland",
                        EmailConfirmed = true,
                        IsActive = true,
                        LastLogin = DateTime.Now,
                        LastPasswordChange = DateTime.Now
                    };
                    PasswordHasher<ApplicationUser> phAdmin = new PasswordHasher<ApplicationUser>();

                    admin.PasswordHash = userhash.HashPassword(admin, "t]rep)I8+UWM&IcS!QU^");

                    await _dbContext.Users.AddAsync(admin);

                    await _dbContext.SaveChangesAsync();

                }
            }
        }
    }
}
