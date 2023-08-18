using MediatR;


namespace Warehouse.Application.Pallets.Queries.GetPalletDetails
{
    public class GetPalletDetailsQuery : IRequest<PalletDetailsVm>
    {
        public Guid ID { get; set; }
    }
}
