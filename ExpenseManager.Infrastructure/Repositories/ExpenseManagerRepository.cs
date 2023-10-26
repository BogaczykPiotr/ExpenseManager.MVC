using ExpenseManager.Application.DTOS;
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

        public async Task<IEnumerable<Category>> GetAllCategories()
            => await _dbContext.Categories.ToListAsync();
        public async Task<IEnumerable<Transfer>> GetAllTransfers(string userId)
        {
            return await _dbContext.Transfers
                .Where(t => t.CreatedById == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<SavingGoal>> GetAllSavingGoals()
            => await _dbContext.SavingGoals.ToListAsync();

        public async Task<SavingGoal> GetLastSavingGoal()
            => await _dbContext.SavingGoals.OrderByDescending(sg => sg.Id).FirstOrDefaultAsync();

        public async Task<Setting> GetSettings()
            => await _dbContext.Settings.OrderByDescending(se => se.Id).FirstOrDefaultAsync();

        public async Task<Transfer> GetByTransferId(int id)
            => await _dbContext.Transfers.FirstAsync(t => t.Id == id);

        public async Task<Category> GetByCategoryId(int id)
            => await _dbContext.Categories.FirstAsync(t => t.Id == id);

        public async Task Commit()
            => _dbContext.SaveChangesAsync();

        public async Task DeleteTransfer(Transfer transfer)
            => _dbContext.Transfers.Remove(transfer);
        public async Task DeleteCategory(Category category)
            => _dbContext.Categories.Remove(category);
    }
}