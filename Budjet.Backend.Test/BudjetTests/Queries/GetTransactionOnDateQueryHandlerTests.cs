using AutoMapper;
using Budjet.Application.Budjet.Queries.GetTransactionOnDate;
using Budjet.Backend.Test.Common;
using Budjet.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Budjet.Backend.Test.BudjetTests.Queries
{
    [Collection("QueryCollection")]
    public class GetTransactionOnDateQueryHandlerTests
    {
        private readonly BudjetDbContext Context;
        private readonly IMapper Mapper;

        public GetTransactionOnDateQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetListTransactionQueryHandler_Success()
        {
            // Arrange
            var handler = new GetTransactionOnDateQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetTransactionOnDateQuery
                {
                    UserId = BudjetContextFactory.UserId,
                    OnDate = BudjetContextFactory.OnDate
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<TransactionOnDateVm>();
            result.Transactions.Count.ShouldBe(3);
            Assert.Equal(1100,result.IncomeOnDate);
            Assert.Equal(10, result.ExpensesOnDate);
        }
    }
}
