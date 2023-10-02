using Warehouse.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Pallets.Commands.UpdatePallet;
using Xunit;
using Warehouse.Application.Common.Exceptions;


namespace Warehouse.Tests.Pallets.Commands
{
    public class UpdatePalletCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdatePalletCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdatePalletCommandHandler(Context);
            var palletID_test = new Guid("1a19c13d-cab0-467b-8776-423eaee61f2a");
            var pallet_width_test = 8000;
            var pallet_height_test = 8000;
            var pallet_depth_test = 8000;


            // Act
            await handler.Handle(new UpdatePalletCommand
            {
                ID = new Guid("1a19c13d-cab0-467b-8776-423eaee61f2a"),
                width = pallet_width_test,
                height = pallet_height_test,
                depth = pallet_depth_test
            },
            CancellationToken.None);
            
            // Assert
            Assert.NotNull(
                await Context.Pallets.SingleOrDefaultAsync(pallet =>
                pallet.ID == palletID_test &&
                pallet.width == pallet_width_test &&
                pallet.height == pallet_height_test &&
                pallet.depth == pallet_depth_test));
        }

        [Fact]
        public async Task UpdatePalletCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdatePalletCommandHandler(Context);

            // Act           
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdatePalletCommand
                    {
                        ID = Guid.NewGuid(),
                    },
                    CancellationToken.None));

        }

    }
}
