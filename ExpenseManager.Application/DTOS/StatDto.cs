using ExpenseManager.Domain.Entities;
namespace ExpenseManager.Application.DTOS
{
    public class StatDto
    {
        public float TotalAmount { get; set; }
        public float Spent { get; set; }
        public float Left { get; set; }
        public SavingGoal? SavingGoal { get; set; }

        public void AddTotalAmountStat(IEnumerable<Transfer> transfers, SavingGoal lastSavingGoal)
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
            TotalAmount = totalIngoingAmountStat;
            Spent = totalOutgoingAmountStat;
            Left = totalIngoingAmountStat - totalOutgoingAmountStat - lastSavingGoal.Goal;
            
        }
    }
}
