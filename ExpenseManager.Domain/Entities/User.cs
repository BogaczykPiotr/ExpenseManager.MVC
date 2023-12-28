using Microsoft.AspNetCore.Identity;

namespace ExpenseManager.Domain.Entities
{
    public class User : IdentityUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
