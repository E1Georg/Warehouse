using MediatR;
using Warehouse.Domain;
using Warehouse.Application.Common.Exceptions;
using Warehouse.Application.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Warehouse.Application.Pallets.Commands.CreatePallet
{
    public class CreatePalletCommandHandler : IRequestHandler<CreatePalletCommand, Guid>
    {
        private readonly IWarehouseDbContext _dbContext;
        public CreatePalletCommandHandler(IWarehouseDbContext dbContext) => _dbContext = dbContext;
        public async Task<Guid> Handle(CreatePalletCommand request, CancellationToken cancellationToken)
        {
            //var entity = await _dbContext.Pallets.FirstOrDefaultAsync(pallet => pallet.Name == request.Name, cancellationToken);

            if (true)//entity == null || entity.Name != request.Name
            {
                var Temp = new Pallet
                {
                    ID = Guid.NewGuid(),
                    width = Math.Round(request.width, 2),
                    height = Math.Round(request.height, 2),
                    depth = Math.Round(request.depth, 2),
                    weight = Math.Round(request.weight, 2),
                    expiration_date = request.expiration_date                    
                };

                await _dbContext.Pallets.AddAsync(Temp, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Temp.ID;
            }
            else
            {
                throw new EntityAlreadyExistException(nameof(Pallet), request.ID);
            }
        }
    }
}
