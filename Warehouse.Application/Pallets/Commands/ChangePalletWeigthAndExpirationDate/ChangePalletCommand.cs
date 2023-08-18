using MediatR;


namespace Warehouse.Application.Pallets.Commands.ChangePalletWeigthAndExpirationDate
{
    public class ChangePalletCommand : IRequest<Unit>
    {
        public Guid ID { get; set; }     
        public double weight { get; set; }
        public DateTime expiration_date { get; set; }
    }
}
