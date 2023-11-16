using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ExpenseManager.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(15)]
        [MinLength(1)]
        public string Name { get; set; }
        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }
    }
}
