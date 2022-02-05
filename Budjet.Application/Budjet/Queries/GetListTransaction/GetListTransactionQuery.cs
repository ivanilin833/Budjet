using MediatR;
using System;

namespace Budjet.Application.Budjet.Queries.GetListTransaction
{
    public class GetListTransactionQuery : IRequest<ListTransactionVm>
    {
        public Guid UserId { get; set;}
        public Guid ListTransactionId { get; set;}
    }
}
