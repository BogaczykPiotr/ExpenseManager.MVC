namespace ExpenseManager.Domain.Entities
{
    public class Stat
    {
        public int Id { get; set; }
        public float TotalAmount { get; set; }
        public float Spent { get; set; }
        public float Left { get; set; }
        public SavingGoal SavingGoal { get; set; }

    }
}
