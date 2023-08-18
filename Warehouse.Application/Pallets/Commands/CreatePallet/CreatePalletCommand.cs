using MediatR;


namespace Warehouse.Application.Pallets.Commands.CreatePallet
{
    public class CreatePalletCommand : IRequest<Guid>
    {
        public Guid ID { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public double depth { get; set; }
        public double weight { get; set; }
        public DateTime expiration_date { get; set; }
    }
}
