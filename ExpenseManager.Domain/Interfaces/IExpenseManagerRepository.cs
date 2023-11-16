using ExpenseManager.Domain.Entities;

namespace ExpenseManager.Domain.Interfaces
{
    public interface IExpenseManagerRepository
    {
        Task<IEnumerable<Transfer>> GetAllTransfers(string Id);
        Task<IEnumerable<SavingGoal>> GetAllSavingGoals(string Id);
        Task<IEnumerable<Category>> GetAllCategories(string Id);

        Task CreateTransfer(Transfer transfer);

        Task CreateSavingGoal(SavingGoal goal);
        Task CreateCategory(Category name);

        

        Task<SavingGoal> GetLastSavingGoal();
        

        Task CreateSettings(Setting settings);

        Task<Setting> GetSettings(string Id);
        Task<Transfer> GetByTransferId(int id);
        Task<Category> GetByCategoryId(int id);
        Task Commit();
        Task DeleteTransfer(Transfer transfer);
        Task DeleteCategory(Category category);
    }
}