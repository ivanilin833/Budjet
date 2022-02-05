using AutoMapper;
using Budjet.Application.Budjet.Queries.GetAllListTransaction;
using Budjet.Backend.Test.Common;
using Budjet.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Budjet.Backend.Test.BudjetTests.Queries
{
    [Collection("QueryCollection")]
    public class GetAllListTransactionQueryHandlerTests
    {
        private readonly BudjetDbContext Context;
        private readonly IMapper Mapper;

        public GetAllListTransactionQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetAllListTransactionQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAllListTransactionQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetAllListTransactionQuery
                {
                    UserId = BudjetContextFactory.UserId,
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<AllListTransactionVm>();
            result.ListTransact.Count.ShouldBe(3);
        }
    }
}
