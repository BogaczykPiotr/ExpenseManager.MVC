﻿namespace ExpenseManager.Domain.Entities
{
    public class Achievement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? AddAt { get; set; }
        public bool IsActive { get; set; }
    }
}
