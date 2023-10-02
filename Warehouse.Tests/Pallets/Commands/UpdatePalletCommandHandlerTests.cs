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
            var updateTitle = "New Title";

            // Act
            await handler.Handle(new UpdatePalletCommand
            {
                ID = WarehouseContextFactory.EntityIdForUpdate,
                depth = updateTitle.Length,
            },
            CancellationToken.None);

            // Assert
            // Assert
            Assert.NotNull(
                await Context.Pallets.SingleOrDefaultAsync(pallet =>
                pallet.ID == WarehouseContextFactory.EntityIdForUpdate &&
                                        pallet.depth == 123));


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
