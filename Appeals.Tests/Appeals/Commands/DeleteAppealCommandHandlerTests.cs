using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Appeals.Application.Appeals.Commands.DeleteAppeal;
using Appeals.Tests.Common;
using Xunit;

namespace Appeals.Tests.Appeals.Commands
{
    public class DeleteAppealCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteAppealCommandHandler_Success()
        {
            var handler = new DeleteAppealCommandHandler(Context);

            await handler.Handle(
                new DeleteAppealCommand
                {
                    Id = AppealsContextFactory.AppealIdForDelete
                }, CancellationToken.None);

            Assert.Null(
                await Context.Appeals.SingleOrDefaultAsync(appeal =>
                appeal.Id == AppealsContextFactory.AppealIdForDelete));
        }
    }
}
