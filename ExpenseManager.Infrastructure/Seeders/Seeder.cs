using ExpenseManager.Application.DTOS;
using ExpenseManager.Domain.Entities;
using ExpenseManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManager.Infrastructure.Seeders
{
    public class Seeder
    {
        private readonly ExpenseDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public Seeder(ExpenseDbContext dbContext,
            IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
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
                if(!_dbContext.Users.Any())
                {
                    var user = new User()
                    {
                        Name = "user",
                        LastName = "user",
                        Email = "user@user",
                        Username = "useruser",
                        Role = new Role()
                        {
                            Name = "user"
                        }
                    };
                    user.Password = _passwordHasher.HashPassword(user, "tVzNB4MR3nhs8th");
                    _dbContext.Users.Add(user);


                    var manager = new User()
                    {
                        Name = "manager",
                        LastName = "manager",
                        Email = "manager@manager",
                        Username = "manager",
                        Role = new Role()
                        {
                            Name = "manager"
                        }
                    };
                    manager.Password = _passwordHasher.HashPassword(manager, "tVzNB4MR3nhs8th");
                    _dbContext.Users.Add(manager);


                    var admin = new User()
                    {
                        Name = "admin",
                        LastName = "admin",
                        Email = "admin@admin",
                        Username = "admin",
                        Role = new Role()
                        {
                            Name = "admin"
                        }
                    };
                    admin.Password = _passwordHasher.HashPassword(admin, "tVzNB4MR3nhs8th");
                    _dbContext.Users.Add(admin);


                    await _dbContext.SaveChangesAsync();

                }
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            { 
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Manager"
                },
                new Role()
                {
                    Name = "Admin"
                },
            };

            return roles;

        }
    }
}
