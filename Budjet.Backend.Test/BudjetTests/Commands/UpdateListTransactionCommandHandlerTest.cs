using Budjet.Application.Budjet.Commands.UpdateListTransaction;
using Budjet.Application.Common.Exceptions;
using Budjet.Backend.Test.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Budjet.Backend.Test.BudjetTests.Commands
{
    public class UpdateListTransactionCommandHandlerTest: TestCommandBase
    {
        [Fact]
        public async Task UpdateListTransactionCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateListTransactionCommandHandler(Context);
            var updatedName = "new name";

            // Act
            await handler.Handle(new UpdateListTransactionCommand
            {
                UserId = BudjetContextFactory.UserId,
                ListTransactionId = BudjetContextFactory.ListTransactionAId,
                Name = updatedName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.ListTransactions.SingleOrDefaultAsync(listTransact =>
                listTransact.ListTransactionId == BudjetContextFactory.ListTransactionAId &&
                listTransact.Name == updatedName ));
        }

        [Fact]
        public async Task UpdateListTransactionCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateListTransactionCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateListTransactionCommand
                    {
                        UserId = Guid.NewGuid(),
                        ListTransactionId = BudjetContextFactory.ListTransactionAId,
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateListTransactionCommandHandler_FailOnWrongListTranasctionId()
        {
            // Arrange
            var handler = new UpdateListTransactionCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateListTransactionCommand
                    {
                        UserId = BudjetContextFactory.UserId,
                        ListTransactionId = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }
    }
}
