using ExpenseManager.Application.ApplicationUser;
using ExpenseManager.Application.DTOS;
using ExpenseManager.Domain.Entities;
using ExpenseManager.Domain.Interfaces;
using ExpenseManager.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Infrastructure.Seeders
{
    public class Seeder
    {
        private readonly ExpenseDbContext _dbContext;
        public Seeder(ExpenseDbContext dbContext, IUserContext userContext)
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
                        NumberOfDisplayedActions = 3,
                    };

                    _dbContext.Add(settings);
                    await _dbContext.SaveChangesAsync();

                }
                if (!_dbContext.SavingGoals.Any())
                {
                    var savingGoal = new SavingGoal()
                    {
                        CreatedAt = DateTime.Now,
                        Goal = 0,
                    };

                    _dbContext.SavingGoals.Add(savingGoal);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
