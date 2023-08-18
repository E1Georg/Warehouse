using MediatR;


namespace Warehouse.Application.Boxes.Commands.UpdateBox
{
    public class UpdateBoxCommand : IRequest<Unit>
    {
        public Guid ID { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public double depth { get; set; }
        public double weight { get; set; }
        public DateTime expiration_date { get; set; }
        public DateTime production_date { get; set; }

        public Guid PalletID { get; set; }       
    }
}
