﻿using Warehouse.Tests.Common;
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
                    ID = new Guid("2a19c13d-cab0-467b-8776-423eaee61f2a"),
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PalletListVm>();
            result.Pallets.Count.ShouldBe(5);
        }
    }
}
