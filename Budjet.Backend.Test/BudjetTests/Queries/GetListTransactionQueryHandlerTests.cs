using AutoMapper;
using Budjet.Application.Budjet.Queries.GetListTransaction;
using Budjet.Backend.Test.Common;
using Budjet.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Budjet.Backend.Test.BudjetTests.Queries
{
    [Collection("QueryCollection")]
    public class GetListTransactionQueryHandlerTests
    {
        private readonly BudjetDbContext Context;
        private readonly IMapper Mapper;

        public GetListTransactionQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetListTransactionQueryHandler_Success()
        {
            // Arrange
            var handler = new GetListTransactionQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetListTransactionQuery
                {
                    UserId = BudjetContextFactory.UserId,
                    ListTransactionId = BudjetContextFactory.ListTransactionAId
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ListTransactionVm>();
            result.Income.Count.ShouldBe(2);
            result.Expenses.Count.ShouldBe(1);
        }
    }
}
