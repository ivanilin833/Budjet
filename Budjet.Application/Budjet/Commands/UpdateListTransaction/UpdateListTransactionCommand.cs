using MediatR;
using System;

namespace Budjet.Application.Budjet.Commands.UpdateListTransaction
{
    public class UpdateListTransactionCommand : IRequest
    {
        public Guid UserId { get; set; }

        public Guid ListTransactionId { get; set; }

        public string Name { get; set; }
    }
}
