using Budjet.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Budjet.Domain;


namespace Budjet.Application.Budjet.Commands.CreateListTransaction
{
    public class CreateListTransactionCommandHandler
        : IRequestHandler<CreateListTransactionCommand, Guid>
    {
        private readonly IBudjetDbContext _dbContext;

        public CreateListTransactionCommandHandler(IBudjetDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateListTransactionCommand request, 
            CancellationToken cancellationToken)
        {
            var listTransaction = new ListTransaction
            {
                UserId = request.UserId,
                Name = request.Name,
                DateCreated = DateTime.Now,
                ListTransactionId = Guid.NewGuid(),
            };

            await _dbContext.ListTransactions.AddAsync(listTransaction, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return listTransaction.ListTransactionId;
        }
    }
}
