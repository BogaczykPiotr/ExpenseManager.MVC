using Microsoft.AspNetCore.Identity;

namespace ExpenseManager.Domain.Entities
{
    public class Setting
    {
        public int Id { get; set; }
        public string? Currency { get; set; }
        public string? Language { get; set; }
        public int NumberOfDisplayedActions { get; set; }
        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }
    }
}





