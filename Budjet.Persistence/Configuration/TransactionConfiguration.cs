using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Budjet.Domain;

namespace Budjet.Persistence.Configuration
{
    internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey("TransactionId");
            builder.HasIndex("ListTransactionId");
            builder.HasOne("Budjet.Domain.ListTransaction", "ListTransaction")
                        .WithMany("Transaction")
                        .HasForeignKey("ListTransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

            builder.Navigation("ListTransaction");
        }
    }
}
