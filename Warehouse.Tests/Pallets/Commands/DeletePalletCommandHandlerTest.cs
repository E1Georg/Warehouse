using Warehouse.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Pallets.Commands.DeletePallet;
using Xunit;
using Warehouse.Application.Common.Exceptions;


namespace Warehouse.Tests.Pallets.Commands
{
    public class DeletePalletCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task DeletePalletCommandHandler_Success()
        {
            // Arrange
            var handler = new DeletePalletCommandHandler(Context);

            // Act
            await handler.Handle(new DeletePalletCommand
            {
                ID = Guid.NewGuid(),
            },
            CancellationToken.None);

            // Assert
            Assert.Null(Context.Pallets.SingleOrDefault(pallet => 
                                        pallet.ID == WarehouseContextFactory.EntityIdForDelete));

        }

        [Fact]
        public async Task DeletePalletCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeletePalletCommandHandler(Context);

            // Act

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeletePalletCommand
                    {
                        ID = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }
    }
}
