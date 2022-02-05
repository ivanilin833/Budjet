using Budjet.Application.Budjet.Commands.CreateListTransaction;
using Budjet.Backend.Test.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Budjet.Backend.Test.BudjetTests.Commands
{
    public class CreateListTransactionCommandHandlerTests: TestCommandBase
    {
        [Fact]
        public async Task CreateListTransactionCommandHandler_Success()
        {

            // Arrange
            var handler = new CreateListTransactionCommandHandler(Context);
            var name = "testCreateList";

            // Act
            var listTransactionId = await handler.Handle(
                new CreateListTransactionCommand
                {
                    UserId = BudjetContextFactory.UserId,
                    Name = name
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.ListTransactions.SingleOrDefaultAsync(listTransact =>
                    listTransact.ListTransactionId == listTransactionId && listTransact.Name == name));
        }
    }
}
