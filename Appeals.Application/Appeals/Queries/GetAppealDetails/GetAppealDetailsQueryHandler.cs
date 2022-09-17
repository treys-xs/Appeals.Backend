using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Appeals.Application.Interfaces;
using Appeals.Application.Commons.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Appeals.Application.Appeals.Queries.GetAppealDetails
{
    public class GetAppealDetailsQueryHandler : IRequestHandler<GetAppealDeatailsQuery, AppealDetailsVm>
    {
        private readonly IAppealsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAppealDetailsQueryHandler(IAppealsDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<AppealDetailsVm> Handle(GetAppealDeatailsQuery request, CancellationToken cancellationToken)
        {
            var appeal = await 
                _dbContext.Appeals
                .Include(appeal => appeal.Type)
                .FirstOrDefaultAsync(appeal => appeal.Id == request.Id, cancellationToken);

            if(appeal == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<AppealDetailsVm>(appeal);
        }
    }
}
