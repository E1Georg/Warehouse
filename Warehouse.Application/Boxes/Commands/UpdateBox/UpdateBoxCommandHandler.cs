using Warehouse.Application.Common.Exceptions;
using Warehouse.Application.Interfaces;
using Warehouse.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Warehouse.Application.Boxes.Commands.UpdateBox
{
    public class UpdateBoxCommandHandler : IRequestHandler<UpdateBoxCommand, Unit>
    {
        private readonly IWarehouseDbContext _dbContext;
        public UpdateBoxCommandHandler(IWarehouseDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateBoxCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Boxes.FirstOrDefaultAsync(box => box.ID == request.ID, cancellationToken);

            if (entity == null || entity.ID != request.ID)
                throw new NotFoundException(nameof(Box), request.ID);

            entity.width = request.width;
            entity.height = request.height;
            entity.depth = request.depth;
            entity.weight = request.weight;
            entity.expiration_date = request.expiration_date;
            entity.production_date = request.production_date;
            entity.PalletID = request.PalletID; 

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
