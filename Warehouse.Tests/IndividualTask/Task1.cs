using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Application.Pallets.Commands.CreatePallet;
using Warehouse.Application.Pallets.Queries.GetPalletDetails;
using Warehouse.Application.Pallets.Queries.GetPalletList;
using Warehouse.Persistence;
using Warehouse.Tests.Common;
using Warehouse.WebProject.Controllers;
using Xunit;

namespace Warehouse.Tests.IndividualTask
{
    [Collection("QueryCollection")]
    public class Task1 : TestCommandBase
    {
        private readonly WarehouseDbContext Context;
        private readonly IMapper Mapper;

        public Task1(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Task_1()
        {
            // Arrange 
            var handler = new GetPalletListQueryHandler(Context, Mapper);

            // Act
            var collection = await handler.Handle(
               new GetPalletListQuery
               {
                   ID = new Guid("2a19c13d-cab0-467b-8776-423eaee61f2a"),
               },
               CancellationToken.None);

            var results = collection.Pallets
              .OrderBy(pallet => pallet.expiration_date)
              .ThenBy(pallet => pallet.weight)
              .GroupBy(p => p.expiration_date)
              .ToList();

            // Assert            
            results.Count.ShouldBe(1);
        }

    }
}
