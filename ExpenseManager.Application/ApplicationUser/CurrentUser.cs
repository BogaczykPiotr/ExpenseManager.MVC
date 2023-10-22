using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.ApplicationUser
{
    public class CurrentUser
    {
        public CurrentUser(string id)
        {
            id = Id;
        }
        public string Id { get; set; }
    }
}
