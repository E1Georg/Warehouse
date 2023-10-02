using AutoMapper;
using Warehouse.Application.Interfaces;
using Warehouse.Application.Common.Mappings;
using Warehouse.Persistence;
using Xunit;


namespace Warehouse.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public WarehouseDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = WarehouseContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IWarehouseDbContext).Assembly));
            }); 

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            WarehouseContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
 