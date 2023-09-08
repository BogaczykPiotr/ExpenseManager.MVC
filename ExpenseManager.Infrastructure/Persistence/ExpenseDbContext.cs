using ExpenseManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.Infrastructure.Persistence
{
    public class ExpenseDbContext : DbContext 
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options)
        {

        }

        public DbSet<SavingGoal> SavingGoals { get; set; }
        public DbSet<Stat> Stats { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Setting> Settings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transfer>()
                .OwnsOne(t => t.Category);
        }
    }
}
