using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.ApplicationUser
{
    public class CurrentUser
    {
        public CurrentUser(string id, string email)
        {
            id = Id;
            email = Email;
        }
        public string Id { get; set; }
        public string Email { get; set; }
    }
}
