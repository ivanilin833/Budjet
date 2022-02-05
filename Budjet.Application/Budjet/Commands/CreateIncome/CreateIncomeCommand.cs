using MediatR;
using System;

namespace Budjet.Application.Budjet.Commands.CreateIncome
{
    public class CreateIncomeCommand : IRequest<Guid>
    {
        public Guid ListTransactionId { get; set; }

        public double Value { get; set; }

        public string Name { get; set; }
    }
}
