using ExpenseManager.Domain.Entities;
using ExpenseManager.Domain.Interfaces;
using ExpenseManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.Infrastructure.Repositories
{
    public class ExpenseManagerRepository : IExpenseManagerRepository
    {
        private readonly ExpenseDbContext _dbContext;
        public ExpenseManagerRepository(ExpenseDbContext dbContext)
        {
            _dbContext = dbContext;

        }


        public async Task CreateSavingGoal(SavingGoal goal)
        {
            _dbContext.Add(goal);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateTransfer(Transfer transfer)
        {
            _dbContext.Add(transfer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateSettings(Setting settings)
        {
            _dbContext.Add(settings);
            await _dbContext.SaveChangesAsync();
        }
        public async Task CreateCategory(Category category)
        {
            _dbContext.Add(category);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<SavingGoal> GetLastSavingGoal()
            => await _dbContext.SavingGoals.OrderByDescending(sg => sg.Id).FirstOrDefaultAsync();

        public async Task<Setting> GetSettings(string Id)
        {
            return await _dbContext.Settings
                .Where(se => se.CreatedById == Id || se.CreatedById == null)
                .OrderByDescending(se => se.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<Transfer> GetByTransferId(int id)
            => await _dbContext.Transfers.FirstAsync(t => t.Id == id);

        public async Task<Category> GetByCategoryId(int id)
            => await _dbContext.Categories.FirstAsync(t => t.Id == id);


        public async Task Commit()
            => await _dbContext.SaveChangesAsync();

        public async Task DeleteTransfer(Transfer transfer)
            => _dbContext.Transfers.Remove(transfer);
        public async Task DeleteCategory(Category category)
            => _dbContext.Categories.Remove(category);
        public async Task DeleteUser(ApplicationUser user)
            => _dbContext.Users.Remove(user);

        public async Task<IEnumerable<Transfer>> GetAllTransfers(string Id)
        {
            return await _dbContext.Transfers
                .Where(t => t.CreatedById == Id || t.CreatedById == null)
                .ToListAsync();
        }

        public async Task<IEnumerable<SavingGoal>> GetAllSavingGoals(string Id)
        {
            return await _dbContext.SavingGoals
                .Where(sg => sg.CreatedById == Id || sg.CreatedById == null)
                .ToListAsync();
        }
        public async Task<IEnumerable<Category>> GetAllCategories(string Id)
        {
            return await _dbContext.Categories
                .Where(c => c.CreatedById == Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
            => await _dbContext.Users.ToListAsync();

        public async Task<ApplicationUser> GetUserById(string id)
            => await _dbContext.Users.FirstAsync(u => u.Id == id);

        public async Task<IEnumerable<Achievement>> GetAllAchievements(string id)
        {
            return await _dbContext.Achievements
                .ToListAsync(); 
        }
    }
}