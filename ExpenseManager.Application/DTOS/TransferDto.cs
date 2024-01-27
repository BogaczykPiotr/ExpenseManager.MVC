using ExpenseManager.Domain.Entities;
namespace ExpenseManager.Application.DTOS
{
    public class TransferDto
    {
        public int Id { get; set; }
        public float Value { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool Ingoing { get; set; }
        public bool Upcoming { get; set; } = false;
        public int TransfersCount { get; set; } = 0;
    }
}
