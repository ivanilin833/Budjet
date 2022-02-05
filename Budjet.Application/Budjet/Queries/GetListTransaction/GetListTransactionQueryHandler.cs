using AutoMapper;
using Budjet.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Budjet.Application.Common.Exceptions;
using Budjet.Domain;


namespace Budjet.Application.Budjet.Queries.GetListTransaction
{
    public class GetListTransactionQueryHandler
        : IRequestHandler<GetListTransactionQuery, ListTransactionVm>
    {
        private readonly IBudjetDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetListTransactionQueryHandler(IBudjetDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ListTransactionVm> Handle(GetListTransactionQuery request, 
            CancellationToken cancellationToken)
        {
            ListTransaction entity = await _dbContext.ListTransactions
                .Include(c => c.Transaction)
                .FirstOrDefaultAsync(listTransaction =>
                listTransaction.ListTransactionId == request.ListTransactionId, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(ListTransaction), request.ListTransactionId);
            }

            return _mapper.Map<ListTransactionVm>(entity);

        }
    }
}
