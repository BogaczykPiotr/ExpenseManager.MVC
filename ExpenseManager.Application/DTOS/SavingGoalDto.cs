﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.DTOS
{
    public class SavingGoalDto
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int Goal { get; set; }
    }
}
