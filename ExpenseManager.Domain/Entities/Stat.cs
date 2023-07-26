using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Domain.Entities
{
    public class Stat
    {
        public int Id { get; set; } 
        public int TotalAmount { get; set; }
        public int Spent { get; set; }
        public int Left { get; set; }
        public SavingGoal Value { get; set; }
    }
}
