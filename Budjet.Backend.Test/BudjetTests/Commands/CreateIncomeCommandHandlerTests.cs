using Budjet.Application.Budjet.Commands.CreateIncome;
using Budjet.Backend.Test.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Budjet.Backend.Test.BudjetTests.Commands
{
    public class CreateIncomeCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateIncomeCommandHandler_Success()
        {

            // Arrange
            var handler = new CreateIncomeCommandHandler(Context);
            var value = 12;
            var name = "testExpenses";

            // Act
            var transactionId = await handler.Handle(
                new CreateIncomeCommand
                {
                    ListTransactionId = BudjetContextFactory.ListTransactionBId,
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

