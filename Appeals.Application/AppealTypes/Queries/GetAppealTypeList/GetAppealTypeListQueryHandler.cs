using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Appeals.Application.Interfaces;

namespace Appeals.Application.AppealTypes.Queries.GetAppealTypeList
{
    public class GetAppealTypeListQueryHandler : IRequestHandler<GetAppealTypeListQuery, AppealTypeListVm>
    {
        private readonly IAppealsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAppealTypeListQueryHandler(IAppealsDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        
        public async Task<AppealTypeListVm> Handle(GetAppealTypeListQuery request, CancellationToken cancellationToken)
        {
            var appealTypes = await
                _dbContext.AppealTypes
                .ProjectTo<AppealTypeDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new AppealTypeListVm { AppealTypes = appealTypes };
        }
    }
}
