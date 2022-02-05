using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Budjet.Domain;

namespace Budjet.Persistence.Configuration
{
    internal class ListTransactionConfiguration : IEntityTypeConfiguration<ListTransaction>
    {
        public void Configure(EntityTypeBuilder<ListTransaction> builder)
        {
            builder.HasKey("ListTransactionId");
            builder.HasIndex("ListTransactionId");
        }
    }
}
