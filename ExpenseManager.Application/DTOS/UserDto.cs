using System.ComponentModel.DataAnnotations;

namespace ExpenseManager.Application.DTOS
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }

    }
}
