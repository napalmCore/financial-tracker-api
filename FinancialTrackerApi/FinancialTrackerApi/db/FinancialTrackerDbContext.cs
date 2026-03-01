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

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Category>()
                .ToTable("Categories");
        }
        #endregion

    }
}

