using Budjet.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Budjet.Domain;


namespace Budjet.Application.Budjet.Commands.CreateExpenses
{
    public class CreateExpensesCommandHandler
         : IRequestHandler<CreateExpensesCommand, Guid>
    {
        private readonly IBudjetDbContext _dbContext;

        public CreateExpensesCommandHandler(IBudjetDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateExpensesCommand request,
            CancellationToken cancellationToken)
        {
            var expenditure = new Transaction
            {
                ListTransactionId = request.ListTransactionId,
                Name = request.Name,
                Value = request.Value,
                TransactionId = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                TypeTransaction = "expenses"
            };

            await _dbContext.Transactions.AddAsync(expenditure, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return expenditure.TransactionId;
        }
    }
}
