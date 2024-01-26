using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.DTOS
{
    public class AchievementDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? AddAt { get; set; }
        public bool IsActive { get; set; }
    }
}
