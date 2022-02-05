using AutoMapper;
using AutoMapper.QueryableExtensions;
using Budjet.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Budjet.Application.Budjet.Queries.GetTransactionOnDate
{
    public class GetTransactionOnDateQueryHandler
        : IRequestHandler<GetTransactionOnDateQuery, TransactionOnDateVm>
    {
        private readonly IBudjetDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTransactionOnDateQueryHandler(IBudjetDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TransactionOnDateVm> Handle(GetTransactionOnDateQuery request,
            CancellationToken cancellationToken)
        {
            var transactionQuery = await _dbContext.Transactions
                .Where( trans => trans.DateCreated.Date == request.OnDate.Date)
                 .ProjectTo<TransactionVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new TransactionOnDateVm { Transactions = transactionQuery };
        }
    }
}
