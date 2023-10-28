using ExpenseManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Domain.Interfaces
{
    public interface IExpenseManagerRepository
    {
        Task<IEnumerable<Transfer>> GetAllTransfers(string id);
        Task<IEnumerable<SavingGoal>> GetAllSavingGoals(string id);
        Task<IEnumerable<Category>> GetAllCategories(string id);

        Task CreateTransfer(Transfer transfer);

        Task CreateSavingGoal(SavingGoal goal);
        Task CreateCategory(Category name);

        

        Task<SavingGoal> GetLastSavingGoal();
        

        Task CreateSettings(Setting settings);

        Task<Setting> GetSettings();
        Task<Transfer> GetByTransferId(int id);
        Task<Category> GetByCategoryId(int id);
        Task Commit();
        Task DeleteTransfer(Transfer transfer);
        Task DeleteCategory(Category category);
    }
}