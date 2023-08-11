﻿using ExpenseManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Domain.Interfaces
{
    public interface IExpenseManagerRepository
    {
        Task<IEnumerable<Transfer>> GetAllTransfers();

        Task CreateTransfer(Transfer transfer);

        Task CreateSavingGoal(SavingGoal goal);

        Task<IEnumerable<SavingGoal>> GetAllSavingGoals();

        Task<SavingGoal> GetLastSavingGoal();
    }
}