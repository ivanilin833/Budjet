using Budjet.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Budjet.Application.Common.Exceptions;
using Budjet.Domain;

namespace Budjet.Application.Budjet.Commands.UpdateListTransaction
{
    public class UpdateListTransactionCommandHandler
        : IRequestHandler<UpdateListTransactionCommand>
    {
        private readonly IBudjetDbContext _dbContext;

        public UpdateListTransactionCommandHandler(IBudjetDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateListTransactionCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.ListTransactions.FirstOrDefaultAsync(listTransaction =>
                    listTransaction.ListTransactionId == request.ListTransactionId, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(ListTransaction), request.ListTransactionId);
            }

            entity.Name = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
