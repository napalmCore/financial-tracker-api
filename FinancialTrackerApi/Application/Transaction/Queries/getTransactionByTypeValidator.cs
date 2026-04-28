using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Transaction.Queries
{
    public class GetTransactionByTypeValidator : FluentValidation.AbstractValidator<GetTransactionsByTypeQuery>
    {
        public GetTransactionByTypeValidator()
        {
            RuleFor(x => x.TypeId).GreaterThan(0).WithMessage("TypeId must be greater than 0");
            RuleFor(x => x.From).LessThanOrEqualTo(x => x.To).WithMessage("From date must be less than or equal to To date");
            RuleFor(x => x.To).GreaterThanOrEqualTo(x => x.From).WithMessage("To date must be greater than or equal to From date");
        }
    }
}
