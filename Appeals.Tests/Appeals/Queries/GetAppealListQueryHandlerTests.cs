using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoMapper;
using Shouldly;
using Appeals.Persistence;
using Appeals.Application.Appeals.Queries.GetAppealList;
using Appeals.Tests.Common;

namespace Appeals.Tests.Appeals.Queries
{
    [Collection("QueryCollection")]
    public class GetAppealListQueryHandlerTests
    {
        private readonly AppealsDbContext _context;
        private readonly IMapper _mapper;

        public GetAppealListQueryHandlerTests(QueryTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public async Task GetAppealListQueryHandler_Success()
        {
            var handler = new GetAppealListQueryHandler(_mapper, _context);

            var result = await handler.Handle(
                new GetAppealListQuery(), CancellationToken.None
                );

            result.ShouldBeOfType<AppealListVm>();
            result.Appeals.Count.ShouldBe(3);
        } 
    }
}
