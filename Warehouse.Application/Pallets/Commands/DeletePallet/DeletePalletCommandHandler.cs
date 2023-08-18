using Warehouse.Application.Common.Exceptions;
using Warehouse.Application.Interfaces;
using Warehouse.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Warehouse.Application.Pallets.Commands.DeletePallet
{
    public class DeletePalletCommandHandler : IRequestHandler<DeletePalletCommand, Unit>
    {
        private readonly IWarehouseDbContext _dbContext;
        public DeletePalletCommandHandler(IWarehouseDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(DeletePalletCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Pallets.FindAsync(new object[] { request.ID }, cancellationToken);

            if (entity == null || entity.ID != request.ID)
                throw new NotFoundException(nameof(Pallet), request.ID);

            var boxes = _dbContext.Boxes.Where(x => x.PalletID == entity.ID).ToList();
            entity.Boxes = boxes;

            _dbContext.Pallets.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
