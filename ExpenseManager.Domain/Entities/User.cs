using System.ComponentModel.DataAnnotations;

namespace ExpenseManager.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(25)]
        public string Email { get; set; }
        public string? Name { get; set; }
        [MaxLength(25)]
        public string? LastName { get; set; }
        [MaxLength(25)]
        public string? Username { get; set; }
        public string? Password { get; set; }
        public Role? Role { get; set; }
        
    }
}
