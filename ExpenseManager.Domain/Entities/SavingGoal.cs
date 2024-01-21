namespace ExpenseManager.Domain.Entities
{
    public class SavingGoal
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int Goal { get; set; }
        public string? CreatedById { get; set; }
        public ApplicationUser? CreatedBy { get; set; }

    }
}
