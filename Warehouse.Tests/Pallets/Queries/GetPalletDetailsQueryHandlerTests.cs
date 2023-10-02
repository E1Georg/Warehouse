using Warehouse.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Pallets.Queries.GetPalletDetails;
using Xunit;
using Warehouse.Application.Common.Exceptions;
using AutoMapper;
using Warehouse.Persistence;
using Shouldly;


namespace Warehouse.Tests.Pallets.Queries
{
    [Collection("QueryCollection")]
    public class GetPalletDetailsQueryHandlerTests
    {
        private readonly WarehouseDbContext Context;
        private readonly IMapper Mapper;

        public GetPalletDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetPalletDetailsQueryHandler_Succecc()
        {
            // Arrange 
            var handler = new GetPalletDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetPalletDetailsQuery
                {
                    ID = WarehouseContextFactory.UserBId,
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PalletDetailsVm>();
            result.depth.ShouldBe(176);
        }
    }
}
