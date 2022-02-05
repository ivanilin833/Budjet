using AutoMapper;
using Budjet.Application.Budjet.Queries.GetTransactionsPerMonth;
using Budjet.Backend.Test.Common;
using Budjet.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Budjet.Backend.Test.BudjetTests.Queries
{
    [Collection("QueryCollection")]
    public class GetTransactionPerMonthQueryHandlerTests
    {
        private readonly BudjetDbContext Context;
        private readonly IMapper Mapper;

        public GetTransactionPerMonthQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetListTransactionQueryHandler_Success()
        {
            // Arrange
            var handler = new GetTransactionPerMonthQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetTransactionPerMonthQuery
                {
                    UserId = BudjetContextFactory.UserId,
                    StartDate = BudjetContextFactory.StartDate,
                    EndDate = BudjetContextFactory.EndDate
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<TransactionPerMonthVm>();
            result.Transactions.Count.ShouldBe(4);
            Assert.Equal(444, result.IncomePerMonth);
            Assert.Equal(555, result.ExpensesPerMonth);
        }
    }
}
