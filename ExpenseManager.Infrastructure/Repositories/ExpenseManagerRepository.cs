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

        public async Task Create(Transfer transfer)
        {
            _dbContext.Add(transfer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Transfer>> GetAllTransfers()
            => await _dbContext.Transfers.ToListAsync();

        }
    }
