using MediatR;
using System;

namespace Budjet.Application.Budjet.Commands.UpdateTransaction
{
    public class UpdateTransactionCommand: IRequest
    {
        public Guid UserId { get; set;}

        public Guid ListTransactionId { get; set; }

        public Guid TransactionId { get; set; }

        public double Value { get; set; }

        public string Name { get; set; }
    }
}
