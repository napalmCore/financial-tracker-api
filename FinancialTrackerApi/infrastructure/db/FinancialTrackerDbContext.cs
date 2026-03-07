using Domaine.Entities;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.db
{
    public class FinancialTrackerDbContext : DbContext
    {
        public FinancialTrackerDbContext(DbContextOptions<FinancialTrackerDbContext> options)
    : base(options)
        {
        }
        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
        public DbSet<TransactionEntity> Transactions => Set<TransactionEntity>();

        public DbSet<TransactionTypeEntity> TransactionTypes => Set<TransactionTypeEntity>();


        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                
        }
        #endregion

    }
}

