using FinancialTrackerApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace FinancialTrackerApi.db
{
    public class FinancialTrackerDbContext : DbContext
    {
        public FinancialTrackerDbContext(DbContextOptions<FinancialTrackerDbContext> options)
    : base(options)
        {
        }
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Transaction> Transactions => Set<Transaction>();

        public DbSet<TransactionType> TransactionTypes => Set<TransactionType>();


        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                
        }
        #endregion

    }
}

