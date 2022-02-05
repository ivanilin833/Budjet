using MediatR;
using System;

namespace Budjet.Application.Budjet.Commands.DeleteTransaction
{
    public class DeleteTransactionCommand : IRequest
    {
        public Guid UserId { get; set;}

        public Guid ListTransactionId { get; set;}

        public Guid TransactionId { get; set;}
    }
}
