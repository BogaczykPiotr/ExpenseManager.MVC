namespace ExpenseManager.Domain.Entities
{
    public class SavingGoal
    {
        public int Id { get; set; }
        public int? Value { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
