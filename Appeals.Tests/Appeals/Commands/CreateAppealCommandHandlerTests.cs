using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Appeals.Tests.Common;
using Appeals.Application.Appeals.Commands.CreateAppeal;
using Xunit;

namespace Appeals.Tests.Appeals.Commands
{
    public class CreateAppealCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateAppealCommand_Success()
        {
            var handler = new CreateAppealCommandHandler(Context);
            var message = "text";
            var email = "asd@mail.ru";
            var phoneNumber = "123";
            var appealType = "A";

            var appealId = await handler.Handle(
                new CreateAppealCommand
                {
                    Message = message,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    TypeName = appealType
                }, CancellationToken.None);

            Assert.NotNull(
                await Context.Appeals.SingleOrDefaultAsync(appeal =>
                    appeal.Id == appealId && appeal.Message == message &&
                    appeal.PhoneNumber == phoneNumber && appeal.Email == email));
        }
    }
}
