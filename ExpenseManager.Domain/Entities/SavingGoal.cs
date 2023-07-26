using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Domain.Entities
{
    public class SavingGoal
    {
        public int Id { get; set; }
        public int? Value { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
