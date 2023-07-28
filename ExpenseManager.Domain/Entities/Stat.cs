﻿namespace ExpenseManager.Domain.Entities
{
    public class Stat
    {
        public int Id { get; set; }
        public float TotalAmount { get; set; }
        public float Spent { get; set; }
        public float Left { get; set; }
        public int UserForeignKey { get; set; }
        public int SavingGoalForeignKey { get; set; }
        public User User { get; set; }
        public SavingGoal SavingGoal { get; set; }

    }
}
