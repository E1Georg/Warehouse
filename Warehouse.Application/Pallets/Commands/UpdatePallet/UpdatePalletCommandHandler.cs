using Warehouse.Application.Common.Exceptions;
using Warehouse.Application.Interfaces;
using Warehouse.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Warehouse.Application.Pallets.Commands.UpdatePallet
{
    public class UpdatePalletCommandHandler : IRequestHandler<UpdatePalletCommand, Unit>
    {
        private readonly IWarehouseDbContext _dbContext;
        public UpdatePalletCommandHandler(IWarehouseDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(UpdatePalletCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Pallets.FirstOrDefaultAsync(pallet => pallet.ID == request.ID, cancellationToken);

            if (entity == null || entity.ID != request.ID)
                throw new NotFoundException(nameof(Pallet), request.ID);

            entity.width = request.width;
            entity.height = request.height;
            entity.depth = request.depth;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
