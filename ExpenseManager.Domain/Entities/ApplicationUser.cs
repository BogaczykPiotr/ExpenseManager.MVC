﻿using Microsoft.AspNetCore.Identity;

namespace ExpenseManager.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string? Address { get; set; }
        [PersonalData]
        public string? Country { get; set; }
        [PersonalData]
        public bool IsActive { get; set; }
        [PersonalData]
        public DateTime LastLogin { get; set; }
        [PersonalData]
        public DateTime CreatedAt { get; set; }
        [PersonalData]
        public DateTime LastPasswordChange { get; set; }
    }
}
