using MediatR;


namespace Warehouse.Application.Boxes.Commands.DeleteBox
{
    public class DeleteBoxCommand : IRequest<Unit>
    {
        public Guid ID { get; set; }
    }
}
