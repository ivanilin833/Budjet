using Budjet.Application.Budjet.Commands.DeleteTransaction;
using Budjet.Application.Common.Exceptions;
using Budjet.Backend.Test.Common;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Budjet.Backend.Test.BudjetTests.Commands
{
    public class DeleteTransactionCommandHandlerTest: TestCommandBase
    {
        [Fact]
        public async Task DeleteTtansactionCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteTransactionCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteTransactionCommand
            {
                UserId = BudjetContextFactory.UserId,
                ListTransactionId = BudjetContextFactory.ListTransactionBId,
                TransactionId = BudjetContextFactory.TransactionIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Transactions.SingleOrDefault(transact =>
                transact.TransactionId == BudjetContextFactory.TransactionIdForDelete));
        }

        [Fact]
        public async Task DeleteTransactionCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteTransactionCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteTransactionCommand
                    {
                        UserId = BudjetContextFactory.UserId,
                        ListTransactionId = BudjetContextFactory.ListTransactionBId,
                        TransactionId = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task DeleteTransactionCommandHandler_FailOnWrongListTransactionId()
        {
            // Arrange
            var handler = new DeleteTransactionCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteTransactionCommand
                    {
                        UserId = BudjetContextFactory.UserId,
                        ListTransactionId = Guid.NewGuid(),
                        TransactionId = BudjetContextFactory.TransactionIdForDelete
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task DeleteTransactionCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new DeleteTransactionCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteTransactionCommand
                    {
                        UserId = Guid.NewGuid(),
                        ListTransactionId = BudjetContextFactory.ListTransactionBId,
                        TransactionId = BudjetContextFactory.TransactionIdForDelete
                    },
                    CancellationToken.None));
        }
    }
}
