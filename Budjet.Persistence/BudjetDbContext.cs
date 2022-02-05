using Microsoft.EntityFrameworkCore;
using Budjet.Domain;
using Budjet.Persistence.Configuration;
using Budjet.Application.Interfaces;

namespace Budjet.Persistence
{
    public class BudjetDbContext: DbContext, IBudjetDbContext
    {
        public BudjetDbContext(DbContextOptions<BudjetDbContext> options)
           : base(options)
        {
        }

        public DbSet<ListTransaction> ListTransactions { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ListTransactionConfiguration());
            builder.ApplyConfiguration(new TransactionConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
