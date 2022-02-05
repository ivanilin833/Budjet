using Budjet.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Budjet.Application.Common.Exceptions;
using Budjet.Domain;


namespace Budjet.Application.Budjet.Commands.UpdateTransaction
{
    public class UpdateTransactionCommandHandler
         : IRequestHandler<UpdateTransactionCommand>
    {
        private readonly IBudjetDbContext _dbContext;

        public UpdateTransactionCommandHandler(IBudjetDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateTransactionCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Transactions.Include(c => c.ListTransaction)
                .FirstOrDefaultAsync(transaction =>
                    transaction.TransactionId == request.TransactionId, cancellationToken);

            if (entity == null || entity.ListTransactionId != request.ListTransactionId || entity.ListTransaction.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Transaction), request.TransactionId);
            }

            entity.Name = request.Name;
            entity.Value = request.Value;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}
