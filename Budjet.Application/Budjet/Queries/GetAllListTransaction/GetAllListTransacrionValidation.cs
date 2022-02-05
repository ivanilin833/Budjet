using Budjet.Application.Budjet.Queries.GetListTransaction;
using FluentValidation;
using System;

namespace Budjet.Application.Budjet.Queries.GetAllListTransaction
{
    public class GetAllListTransacrionValidation: AbstractValidator<GetListTransactionQuery>
    {
        public GetAllListTransacrionValidation()
        {
            RuleFor(query =>
                query.UserId).NotEqual(Guid.Empty);
        }
    }
}
