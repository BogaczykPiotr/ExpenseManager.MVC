using ExpenseManager.Domain.Entities;
using ExpenseManager.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Infrastructure.Seeders
{
    public class SavingGoalSeeder
    {
        private readonly ExpenseDbContext _dbContext;
        public SavingGoalSeeder(ExpenseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {
                if(! _dbContext.SavingGoals.Any())
                {
                    var savingGoal = new Domain.Entities.SavingGoal()
                    { 
                        CreatedAt = DateTime.Now,
                        Goal = 0
                    };

                    _dbContext.SavingGoals.Add(savingGoal);
                    await _dbContext.SaveChangesAsync();

                }
            }
        }
    }
}
