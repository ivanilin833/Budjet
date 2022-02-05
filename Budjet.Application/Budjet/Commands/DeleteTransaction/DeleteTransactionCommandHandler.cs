using Budjet.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Budjet.Application.Common.Exceptions;
using Budjet.Domain;


namespace Budjet.Application.Budjet.Commands.DeleteTransaction
{
    public class DeleteTransactionCommandHandler
     : IRequestHandler<DeleteTransactionCommand>
    {
        private readonly IBudjetDbContext _dbContext;

        public DeleteTransactionCommandHandler(IBudjetDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteTransactionCommand request,
            CancellationToken cancellationToken)
        {
            Transaction entity = await _dbContext.Transactions
               .Include(c => c.ListTransaction)
               .FirstOrDefaultAsync(transaction =>
               transaction.TransactionId == request.TransactionId, cancellationToken);



            if (entity == null || entity.ListTransactionId != request.ListTransactionId || entity.ListTransaction.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Transaction), request.TransactionId);
            }

            _dbContext.Transactions.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
