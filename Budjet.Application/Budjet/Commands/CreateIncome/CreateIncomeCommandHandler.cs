using Budjet.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Budjet.Domain;


namespace Budjet.Application.Budjet.Commands.CreateIncome
{
    public class CreateIncomeCommandHandler
        : IRequestHandler<CreateIncomeCommand, Guid>
    {
        private readonly IBudjetDbContext _dbContext;

        public CreateIncomeCommandHandler(IBudjetDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateIncomeCommand request,
            CancellationToken cancellationToken)
        {
            var expenditure = new Transaction
            {
                ListTransactionId = request.ListTransactionId,
                Name = request.Name,
                Value = request.Value,
                TransactionId = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                TypeTransaction = "income"
            };

            await _dbContext.Transactions.AddAsync(expenditure, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return expenditure.TransactionId;
        }
    }
}
