using FluentValidation;
using System;

namespace Budjet.Application.Budjet.Queries.GetTransactionOnDate
{
    public class GetTransactionOnDateValidator: AbstractValidator<GetTransactionOnDateQuery>
    {
        public GetTransactionOnDateValidator()
        {
            RuleFor(query =>
                query.UserId).NotEqual(Guid.Empty);
            RuleFor(query =>
                query.OnDate).NotEmpty();
        }
    }
}
