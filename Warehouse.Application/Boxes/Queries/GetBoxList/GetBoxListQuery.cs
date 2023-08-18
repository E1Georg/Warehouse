using MediatR;


namespace Warehouse.Application.Boxes.Queries.GetBoxList
{
    public class GetBoxListQuery : IRequest<BoxListVm>
    {
        public Guid ID { get; set; }
    }
}
