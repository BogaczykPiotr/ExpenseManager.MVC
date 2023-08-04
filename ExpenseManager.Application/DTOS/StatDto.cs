using ExpenseManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.DTOS
{
    public class StatDto
    {
        public float TotalAmount { get; set; }
        public float Spent { get; set; }
        public float Left { get; set; }
        public SavingGoal SavingGoal { get; set; }
    }
}
