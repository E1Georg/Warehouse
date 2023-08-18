using MediatR;


namespace Warehouse.Application.Boxes.Queries.GetBoxDetails
{
    public class GetBoxDetailsQuery : IRequest<BoxDetailsVm>
    {
        public Guid ID { get; set; }
    }
}
