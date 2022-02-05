using FluentValidation;
using System;

namespace Budjet.Application.Budjet.Commands.CreateIncome
{
    public class CreateIncomeValidator: AbstractValidator<CreateIncomeCommand>
    {
        public CreateIncomeValidator()
        {
            RuleFor(command =>
             command.ListTransactionId).NotEqual(Guid.Empty);
            RuleFor(command =>
                command.Name).NotEmpty();
            RuleFor(command =>
                command.Value).NotEqual(double.NaN);
        }
    }
}
