using Warehouse.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Pallets.Commands.CreatePallet;
using Xunit;


namespace Warehouse.Tests.Pallets.Commands
{
    public class CreatePalletCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task CreatePalletCommandHandler_Success()
        {
            // Arrange 
            var handler = new CreatePalletCommandHandler(Context);
            var palletName = "testPalletName";
            var palletDetails = "testPalletDetails";

            // Act
            var palletId = await handler.Handle(
                new CreatePalletCommand
                {
                    ID = Guid.NewGuid(),                   
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Pallets.SingleOrDefaultAsync(pallet =>
                                        pallet.ID.ToString() == palletName && 
                                        pallet.depth.ToString() == palletDetails));


        }
    }
}
