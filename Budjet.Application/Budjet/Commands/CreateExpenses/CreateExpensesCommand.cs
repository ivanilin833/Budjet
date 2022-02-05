using MediatR;
using System;

namespace Budjet.Application.Budjet.Commands.CreateExpenses
{
    public class CreateExpensesCommand : IRequest<Guid>
    {
        public Guid ListTransactionId { get; set; }

        public double Value { get; set; }

        public string Name { get; set; }
    }
}
