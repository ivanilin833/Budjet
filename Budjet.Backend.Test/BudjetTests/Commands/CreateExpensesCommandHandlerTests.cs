using Budjet.Application.Budjet.Commands.CreateExpenses;
using Budjet.Backend.Test.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Budjet.Backend.Test.BudjetTests.Commands
{
    public class CreateExpensesCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateExpensesCommandHandler_Success()
        {

            // Arrange
            var handler = new CreateExpensesCommandHandler(Context);
            var value = 12;
            var name = "testExpenses";

            // Act
            var transactionId = await handler.Handle(
                new CreateExpensesCommand
                {
                    ListTransactionId = BudjetContextFactory.ListTransactionAId,
                    Value = value,
                    Name = name
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Transactions.SingleOrDefaultAsync(transact =>
                    transact.TransactionId == transactionId && transact.Name == name &&
                    transact.Value == value));
        }
    }
}
