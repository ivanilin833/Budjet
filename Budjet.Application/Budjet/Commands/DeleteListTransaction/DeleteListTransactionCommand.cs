using MediatR;
using System;

namespace Budjet.Application.Budjet.Commands.DeleteListTransaction
{
    public class DeleteListTransactionCommand: IRequest
    {
        public Guid UserId { get; set; }

        public Guid ListTransactionId { get; set; }
    }
}
