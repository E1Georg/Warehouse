using Warehouse.Application.Common.Exceptions;
using Warehouse.Application.Interfaces;
using Warehouse.Domain;
using MediatR;


namespace Warehouse.Application.Boxes.Commands.DeleteBox
{
    public class DeleteBoxCommandHandler : IRequestHandler<DeleteBoxCommand, Unit>
    {
        private readonly IWarehouseDbContext _dbContext;
        public DeleteBoxCommandHandler(IWarehouseDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteBoxCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Boxes.FindAsync(new object[] { request.ID }, cancellationToken);

            if (entity == null || entity.ID != request.ID)
                throw new NotFoundException(nameof(Box), request.ID);

            _dbContext.Boxes.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
