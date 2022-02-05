using FluentValidation;
using System;

namespace Budjet.Application.Budjet.Commands.UpdateListTransaction
{
    public class UpdateListTransactionValidator: AbstractValidator<UpdateListTransactionCommand>
    {
        public UpdateListTransactionValidator()
        {
            RuleFor(command =>
                command.ListTransactionId).NotEqual(Guid.Empty);
            RuleFor(command =>
                command.UserId).NotEqual(Guid.Empty);
            RuleFor(command =>
                command.Name).NotEmpty();
        }
    }
}
