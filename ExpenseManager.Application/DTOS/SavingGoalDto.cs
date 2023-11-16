namespace ExpenseManager.Application.DTOS
{
    public class SavingGoalDto
    {
        public int Id { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int Goal { get; set; }
    }
}
