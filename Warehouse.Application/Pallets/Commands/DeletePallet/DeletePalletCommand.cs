using MediatR;


namespace Warehouse.Application.Pallets.Commands.DeletePallet
{
    public class DeletePalletCommand : IRequest<Unit>
    {
        public Guid ID { get; set; }
    }
}
