using MediatR;
using System;

namespace Budjet.Application.Budjet.Queries.GetAllListTransaction
{
    public class GetAllListTransactionQuery : IRequest<AllListTransactionVm>
    {
        public Guid UserId { get; set;}
    }
}
