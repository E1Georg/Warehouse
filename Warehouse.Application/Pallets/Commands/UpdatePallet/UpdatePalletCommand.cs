using MediatR;


namespace Warehouse.Application.Pallets.Commands.UpdatePallet
{
    public class UpdatePalletCommand : IRequest<Unit>
    {
        public Guid ID { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public double depth { get; set; }
        
    }
}
