using System;
using MediatR;

namespace Appeals.Application.Appeals.Queries.GetAppealDetails
{
    public class GetAppealDeatailsQuery : IRequest<AppealDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
