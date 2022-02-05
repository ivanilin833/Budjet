using MediatR;
using System;

namespace Budjet.Application.Budjet.Queries.GetTransactionsPerMonth
{
    public class GetTransactionPerMonthQuery : IRequest<TransactionPerMonthVm>
    {
        public Guid UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
