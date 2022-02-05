using FluentValidation;
using System;

namespace Budjet.Application.Budjet.Commands.CreateExpenses
{
    public class CreateExpensesValidator: AbstractValidator<CreateExpensesCommand>
    {
        public CreateExpensesValidator()
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
