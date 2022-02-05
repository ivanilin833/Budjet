using FluentValidation;
using System;

namespace Budjet.Application.Budjet.Commands.DeleteListTransaction
{
    public class DeleteListTransactionValidator: AbstractValidator<DeleteListTransactionCommand>
    {
        public DeleteListTransactionValidator()
        {
            RuleFor(command =>
             command.ListTransactionId).NotEqual(Guid.Empty);
            RuleFor(command =>
                command.UserId).NotEqual(Guid.Empty);
        }   
    }
}
