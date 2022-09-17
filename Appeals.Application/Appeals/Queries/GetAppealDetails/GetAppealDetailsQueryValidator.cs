using System;
using FluentValidation;

namespace Appeals.Application.Appeals.Queries.GetAppealDetails
{
    public class GetAppealDetailsQueryValidator : AbstractValidator<GetAppealDeatailsQuery>
    {
        public GetAppealDetailsQueryValidator()
        {
            RuleFor(getAppealDetails =>
                getAppealDetails.Id).NotEqual(Guid.Empty);
        }
    }
}
