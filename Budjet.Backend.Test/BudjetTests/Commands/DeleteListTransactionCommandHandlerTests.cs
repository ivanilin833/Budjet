using Budjet.Application.Budjet.Commands.DeleteListTransaction;
using Budjet.Application.Common.Exceptions;
using Budjet.Backend.Test.Common;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Budjet.Backend.Test.BudjetTests.Commands
{
    public class DeleteListTransactionCommandHandlerTests: TestCommandBase
    {
        [Fact]
        public async Task DeleteListTransactionCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteListTransactionCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteListTransactionCommand
            {
                UserId = BudjetContextFactory.UserId,
                ListTransactionId = BudjetContextFactory.ListTransactionBId,
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.ListTransactions.SingleOrDefault(listTransact =>
                listTransact.ListTransactionId == BudjetContextFactory.ListTransactionBId));
        }

        
        [Fact]
        public async Task DeleteListTransactionCommandHandler_FailOnWrongListTransactionId()
        {
            // Arrange
            var handler = new DeleteListTransactionCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteListTransactionCommand
                    {
                        UserId = BudjetContextFactory.UserId,
                        ListTransactionId = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task DeleteListTransactionCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new DeleteListTransactionCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteListTransactionCommand
                    {
                        UserId = Guid.NewGuid(),
                        ListTransactionId = BudjetContextFactory.ListTransactionBId,
                    },
                    CancellationToken.None));
        }
    }
}
