using Budjet.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Budjet.Application.Common.Exceptions;
using Budjet.Domain;


namespace Budjet.Application.Budjet.Commands.DeleteListTransaction
{
    public class DeleteListTransactionCommandHandler
        : IRequestHandler<DeleteListTransactionCommand>
    {
        private readonly IBudjetDbContext _dbContext;

        public DeleteListTransactionCommandHandler(IBudjetDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteListTransactionCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ListTransactions
                .FindAsync(new object[] { request.ListTransactionId }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(ListTransaction), request.ListTransactionId);
            }

            _dbContext.ListTransactions.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
