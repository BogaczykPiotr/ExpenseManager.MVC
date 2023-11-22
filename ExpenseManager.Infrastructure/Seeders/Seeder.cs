﻿using ExpenseManager.Domain.Entities;
using ExpenseManager.Infrastructure.Persistence;

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
                if(!_dbContext.Users.Any())
                {
                    var user = new User()
                    {
                        Name = "Test",
                        LastName = "Tests",
                        Username = "TestTests",
                    };

                    _dbContext.Users.Add(user);
                    await _dbContext.SaveChangesAsync();

                }

            }
        }
    }
}
