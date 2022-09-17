using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoMapper;
using Shouldly;
using Appeals.Persistence;
using Appeals.Application.Appeals.Queries.GetAppealDetails;
using Appeals.Tests.Common;

namespace Appeals.Tests.Appeals.Queries
{
    [Collection("QueryCollection")]
    public class GetAppealDetailsQueryHandlerTests
    {
        private readonly AppealsDbContext _context;
        private readonly IMapper _mapper;

        public GetAppealDetailsQueryHandlerTests(QueryTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public async Task GetAppealDetailsQueryHandler_Success()
        {
            var handler = new GetAppealDetailsQueryHandler(_context, _mapper);

            var result = await handler.Handle(
                new GetAppealDeatailsQuery
                {
                    Id = Guid.Parse("AC0E21CA-1F3F-4860-806B-37509CC9D21C")
                }, CancellationToken.None);

            result.ShouldBeOfType<AppealDetailsVm>();
            result.TypeName.ShouldBe("A");
            result.Message.ShouldBe("Message1");
            result.Email.ShouldBe("Email1");
            result.PhoneNumber.ShouldBe("Number1");
        }
    }
}
