using MediatR;


namespace Warehouse.Application.Pallets.Queries.GetPalletList
{
    public class GetPalletListQuery : IRequest<PalletListVm>
    {
        public Guid ID { get; set; }
    }
}
