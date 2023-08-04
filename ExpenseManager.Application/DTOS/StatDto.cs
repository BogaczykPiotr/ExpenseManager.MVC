using ExpenseManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.DTOS
{
    public class StatDto
    {
        public float TotalAmount { get; set; }
        public float Spent { get; set; }
        public float Left { get; set; }
        public SavingGoal SavingGoal { get; set; }

        public void AddTotalAmountStat(IEnumerable<Transfer> transfers)
        {
            DateTime Month = DateTime.Now.AddDays(-30);
            float TotalAmountStat = transfers
                .Where(transfer => transfer.CreatedAt >= Month)
                .Sum(transfer => transfer.Value);

            TotalAmount = TotalAmountStat;
        }
    }
}
