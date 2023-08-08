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

        public async void AddTotalAmountStat(IEnumerable<Transfer> transfers)
        {
            DateTime month = DateTime.Now.AddDays(-30);
            float totalIngoingAmountStat = 0;
            float totalOutgoingAmountStat = 0;


            foreach (var transfer in transfers.Where(t => t.CreatedAt >= month))
            {
                if (transfer.Ingoing)
                    totalIngoingAmountStat += transfer.Value;
                else
                    totalOutgoingAmountStat += transfer.Value;
            }
            TotalAmount = (totalIngoingAmountStat - totalOutgoingAmountStat) * -1;
            Spent = totalOutgoingAmountStat;
            Left = (totalIngoingAmountStat - totalOutgoingAmountStat - 0) * -1; //To fix
            
        }
    }
}
