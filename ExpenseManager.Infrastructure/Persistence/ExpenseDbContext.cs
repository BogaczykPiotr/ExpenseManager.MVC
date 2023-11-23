using ExpenseManager.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.Infrastructure.Persistence
{
    public class ExpenseDbContext : IdentityDbContext 
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options)
        {

        }

        public DbSet<SavingGoal> SavingGoals { get; set; }
        public DbSet<Stat> Stats { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
