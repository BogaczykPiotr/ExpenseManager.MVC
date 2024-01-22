using ExpenseManager.Domain.Entities;
using ExpenseManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManager.Infrastructure.Seeders
{
    public class Seeder
    {
        private readonly ExpenseDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public Seeder(ExpenseDbContext dbContext,
            UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
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
                        LastPasswordChange = DateTime.Now,
                    };

                    admin.PasswordHash = userhash.HashPassword(admin, "t]rep)I8+UWM&IcS!QU^");

                    

                    await _dbContext.Users.AddAsync(admin);



                    var moderator = new ApplicationUser()
                    {
                        UserName = "moderator",
                        Email = "moderator@moderator",
                        NormalizedEmail = "MODERATOR@MODERATOR",
                        NormalizedUserName = "MODERATOR",
                        Address = "moderator",
                        CreatedAt = DateTime.Now,
                        Country = "Poland",
                        EmailConfirmed = true,
                        IsActive = true,
                        LastLogin = DateTime.Now,
                        LastPasswordChange = DateTime.Now,
                    };

                    moderator.PasswordHash = userhash.HashPassword(moderator, "t]rep)I8+UWM&IcS!QU^");

                    await _dbContext.Users.AddAsync(moderator);

                    await _dbContext.SaveChangesAsync();

                    await _userManager.AddToRoleAsync(moderator, "moderator");
                    await _userManager.AddToRoleAsync(user, "user");
                    await _userManager.AddToRoleAsync(admin, "admin");

                    var firstLogin = new Achievement()
                    {
                        Name = "First Login",
                    };
                    var firstTransfer = new Achievement()
                    {
                        Name = "First Transfer",
                    };
                    var tenTransfers = new Achievement()
                    {
                        Name = "Ten Transfers",
                    };
                    var hundredTransfers = new Achievement()
                    {
                        Name = "Hundred Transfers",
                    };
                    var aThousandTransfers = new Achievement()
                    {
                        Name = "A Thousand Transfers",
                    };
                }
            }
        }
    }
}
