using System.ComponentModel.DataAnnotations;

namespace ExpenseManager.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(25)]
        public string? Name { get; set; }
        [MaxLength(25)]
        public string? LastName { get; set; }
        [MaxLength(25)]
        public string? Username { get; set; }
        
    }
}
