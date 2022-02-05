using AutoMapper;
using Budjet.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Budjet.Application.Common.Exceptions;
using Budjet.Domain;
using Budjet.Application.Budjet.Queries.GetListTransaction;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace Budjet.Application.Budjet.Queries.GetAllListTransaction
{
    public class GetAllListTransactionQueryHandler
        : IRequestHandler<GetAllListTransactionQuery, AllListTransactionVm>
    {
        private readonly IBudjetDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllListTransactionQueryHandler(IBudjetDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<AllListTransactionVm> Handle(GetAllListTransactionQuery request, 
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ListTransactions
                .Include(c => c.Transaction)
                .Where(listTransaction =>
                listTransaction.UserId == request.UserId)
                .ProjectTo<ListTransactionVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new AllListTransactionVm { ListTransact = entity };

        }
    }
}
