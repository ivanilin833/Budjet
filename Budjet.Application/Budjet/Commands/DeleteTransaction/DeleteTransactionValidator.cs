using FluentValidation;
using System;

namespace Budjet.Application.Budjet.Commands.DeleteTransaction
{
    public class DeleteTransactionValidator: AbstractValidator<DeleteTransactionCommand>
    {
        public DeleteTransactionValidator()
        {
            RuleFor(command =>
                command.ListTransactionId).NotEqual(Guid.Empty);
            RuleFor(command =>
                command.UserId).NotEqual(Guid.Empty);
            RuleFor(command =>
                command.TransactionId).NotEqual(Guid.Empty);
        }
    }
}
