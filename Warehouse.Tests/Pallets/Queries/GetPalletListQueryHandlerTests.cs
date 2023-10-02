using Warehouse.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Pallets.Queries.GetPalletList;
using Xunit;
using Warehouse.Application.Common.Exceptions;
using AutoMapper;
using Warehouse.Persistence;
using Shouldly;


namespace Warehouse.Tests.Pallets.Queries
{
    [Collection("QueryCollection")]
    public class GetPalletListQueryHandlerTests
    {
        private readonly WarehouseDbContext Context;
        private readonly IMapper Mapper; 

        public GetPalletListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetPalletListQueryHandler_Succecc()
        {
            // Arrange 
            var handler = new GetPalletListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetPalletListQuery
                {
                    ID = WarehouseContextFactory.UserBId,
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PalletListVm>();
            result.Pallets.Count.ShouldBe(2);
        }
    }
}
