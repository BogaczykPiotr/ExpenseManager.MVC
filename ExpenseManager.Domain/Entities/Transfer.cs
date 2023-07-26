using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Domain.Entities
{
    public class Transfer
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Description { get; set; }
    }
}
