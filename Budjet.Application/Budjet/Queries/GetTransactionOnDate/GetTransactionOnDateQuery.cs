using MediatR;
using System;

namespace Budjet.Application.Budjet.Queries.GetTransactionOnDate
{
    public class GetTransactionOnDateQuery : IRequest<TransactionOnDateVm>
    {
        public Guid UserId { get; set;}
        public DateTime OnDate { get; set; }
    }
}
