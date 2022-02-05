using FluentValidation;
using System;

namespace Budjet.Application.Budjet.Commands.CreateListTransaction
{
    public class CreateListTransactionValidator: AbstractValidator<CreateListTransactionCommand>
    {
        public CreateListTransactionValidator()
        {
            RuleFor(command =>
             command.UserId).NotEqual(Guid.Empty);
            RuleFor(command =>
                command.Name).NotEmpty();
        }
    }
}
