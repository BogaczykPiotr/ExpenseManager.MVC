using System.ComponentModel.DataAnnotations;

namespace ExpenseManager.Domain.Entities
{
    public class Transfer
    {
        public int Id { get; set; }
        [MinLength(1)]
        public float Value { get; set; }
        public Category Category { get; set; }
        [MinLength(2)]
        [MaxLength(255)]
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool Ingoing { get; set; }
        public bool Upcoming { get; set; } = false;
        public string? CreatedById { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
    }
}
