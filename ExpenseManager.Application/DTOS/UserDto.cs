using Microsoft.AspNetCore.Identity;

namespace ExpenseManager.Application.DTOS
{
    public class UserDto
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }


        public string Address { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastPasswordChange { get; set; }

        public ICollection<IdentityUserRole<string>> Roles { get; } = new List<IdentityUserRole<string>>();
    }
}
