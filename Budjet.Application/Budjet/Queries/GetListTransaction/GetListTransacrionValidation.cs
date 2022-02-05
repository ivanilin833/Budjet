using FluentValidation;
using System;

namespace Budjet.Application.Budjet.Queries.GetListTransaction
{
    public class GetListTransacrionValidation: AbstractValidator<GetListTransactionQuery>
    {
        public GetListTransacrionValidation()
        {
            RuleFor(query =>
                query.UserId).NotEqual(Guid.Empty);
            RuleFor(query =>
                query.ListTransactionId).NotEqual(Guid.Empty);
        }
    }
}
