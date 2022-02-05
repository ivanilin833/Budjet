using Budjet.Application.Budjet.Commands.UpdateTransaction;
using Budjet.Application.Common.Exceptions;
using Budjet.Backend.Test.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Budjet.Backend.Test.BudjetTests.Commands
{
    public class UpdateTransactionCommandHandlerTests:TestCommandBase
    {
        [Fact]
        public async Task UpdateTransactionCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateTransactionCommandHandler(Context);
            var updatedName = "new name";
            var updateValue = 1000000;

            // Act
            await handler.Handle(new UpdateTransactionCommand
            {
                UserId = BudjetContextFactory.UserId,
                ListTransactionId = BudjetContextFactory.ListTransactionAId,
                TransactionId = BudjetContextFactory.TransactionIdForUpdate,
                Name = updatedName,
                Value = updateValue
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Transactions.SingleOrDefaultAsync(transact =>
                transact.TransactionId == BudjetContextFactory.TransactionIdForUpdate &&
                transact.Name == updatedName &&
                transact.Value == updateValue));
        }

        [Fact]
        public async Task UpdateTransactionCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateTransactionCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateTransactionCommand
                    {
                        UserId = Guid.NewGuid(),
                        ListTransactionId = BudjetContextFactory.ListTransactionAId,
                        TransactionId = BudjetContextFactory.TransactionIdForUpdate
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateTransactionCommandHandler_FailOnWrongListTransactionId()
        {
            // Arrange
            var handler = new UpdateTransactionCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateTransactionCommand
                    {
                        UserId = BudjetContextFactory.UserId,
                        ListTransactionId = Guid.NewGuid(),
                        TransactionId = BudjetContextFactory.TransactionIdForUpdate
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateTransactionCommandHandler_FailOnWrongTransactionId()
        {
            // Arrange
            var handler = new UpdateTransactionCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateTransactionCommand
                    {
                        UserId = BudjetContextFactory.UserId,
                        ListTransactionId = BudjetContextFactory.ListTransactionAId,
                        TransactionId = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
