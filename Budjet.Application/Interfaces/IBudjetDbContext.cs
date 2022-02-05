using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Budjet.Domain;

namespace Budjet.Application.Interfaces
{
    public interface IBudjetDbContext
    {
        DbSet<ListTransaction> ListTransactions { get; set; }
        DbSet<Transaction> Transactions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
