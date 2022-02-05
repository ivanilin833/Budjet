using AutoMapper;
using AutoMapper.QueryableExtensions;
using Budjet.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Budjet.Application.Budjet.Queries.GetTransactionOnDate;

namespace Budjet.Application.Budjet.Queries.GetTransactionsPerMonth
{
    public class GetTransactionPerMonthQueryHandler 
        : IRequestHandler<GetTransactionPerMonthQuery, TransactionPerMonthVm>
    {
        private readonly IBudjetDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTransactionPerMonthQueryHandler(IBudjetDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TransactionPerMonthVm> Handle(GetTransactionPerMonthQuery request,
            CancellationToken cancellationToken)
        {
            var transactionQuery = await _dbContext.Transactions
                .Where(transaction => transaction.ListTransaction.UserId == request.UserId)
                .Where(transaction => transaction.DateCreated.Date>=request.StartDate.Date &&
                                      transaction.DateCreated.Date<=request.EndDate.Date)
                .ProjectTo<TransactionVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new TransactionPerMonthVm { Transactions = transactionQuery };
        }
    }
}
