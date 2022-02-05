using FluentValidation;
using System;

namespace Budjet.Application.Budjet.Commands.UpdateTransaction
{
    public class UpdateTransactionValidator: AbstractValidator<UpdateTransactionCommand>
    {
        public UpdateTransactionValidator()
        {
            RuleFor(command =>
                command.UserId).NotEqual(Guid.Empty);
            RuleFor(command =>
                command.ListTransactionId).NotEqual(Guid.Empty);
            RuleFor(command =>
                command.TransactionId).NotEqual(Guid.Empty);
            RuleFor(command =>
                command.Name).NotEmpty();
            RuleFor(command =>
               command.Value).NotEqual(double.NaN);
        }
    }
}
