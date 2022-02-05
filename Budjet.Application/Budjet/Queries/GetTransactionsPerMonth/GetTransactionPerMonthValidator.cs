using FluentValidation;
using System;

namespace Budjet.Application.Budjet.Queries.GetTransactionsPerMonth
{
    public class GetTransactionPerMonthValidator : AbstractValidator<GetTransactionPerMonthQuery>
    {
        public GetTransactionPerMonthValidator()
        {
            RuleFor(query =>
                query.UserId).NotEqual(Guid.Empty);
            RuleFor(query =>
                query.StartDate).NotEmpty();
            RuleFor(query =>
                query.EndDate).NotEmpty();
        }
    }
}
