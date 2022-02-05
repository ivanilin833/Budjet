using AutoMapper;
using Budjet.Application.Common.Mappings;
using Budjet.Application.Interfaces;
using Budjet.Persistence;
using System;
using Xunit;

namespace Budjet.Backend.Test.Common
{
    public class QueryTestFixture: IDisposable
    {
        public BudjetDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = BudjetContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IBudjetDbContext).Assembly));
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            BudjetContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
