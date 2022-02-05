using MediatR;
using System;

namespace Budjet.Application.Budjet.Commands.CreateListTransaction
{
    public class CreateListTransactionCommand: IRequest<Guid>
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }
    }
}
