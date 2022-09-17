using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Appeals.Application.Interfaces;

namespace Appeals.Application.Appeals.Queries.GetAppealList
{
    public class GetAppealListQueryHandler : IRequestHandler<GetAppealListQuery, AppealListVm>
    {
        private readonly IMapper _mapper;
        private readonly IAppealsDbContext _dbContext;

        public GetAppealListQueryHandler(IMapper mapper, IAppealsDbContext dbContext) =>
            (_mapper, _dbContext) = (mapper, dbContext);

        public async Task<AppealListVm> Handle(GetAppealListQuery request, CancellationToken cancellationToken)
        {
            var appeals = await
                _dbContext.Appeals
                .Include(appeal => appeal.Type)
                .ProjectTo<AppealLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new AppealListVm { Appeals = appeals };
        }
    }
}
