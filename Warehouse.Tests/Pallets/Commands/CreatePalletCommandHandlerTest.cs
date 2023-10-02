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

            // Act
            var palletId = await handler.Handle(
                new CreatePalletCommand
                {
                    ID = new Guid("6a19c13d-cab0-467b-8776-423eaee61f2a"),
                    width = 9000,
                    height = 9000,
                    depth = 9000,
                    weight = 30                   
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Pallets.SingleOrDefaultAsync(pallet =>
                                        pallet.ID == palletId));
        }
    }
}
