namespace ExpenseManager.Application.DTOS
{
    public class TransferDto
    {
        public float Amount { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
    }
}
