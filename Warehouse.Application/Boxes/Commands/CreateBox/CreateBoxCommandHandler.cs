using MediatR;
using Warehouse.Domain;
using Warehouse.Application.Common.Exceptions;
using Warehouse.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;


namespace Warehouse.Application.Boxes.Commands.CreateBox
{
    public class CreateBoxCommandHandler : IRequestHandler<CreateBoxCommand, Guid>
    {
        private readonly IWarehouseDbContext _dbContext;
        public CreateBoxCommandHandler(IWarehouseDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateBoxCommand request, CancellationToken cancellationToken)
        {
            //var entity = await _dbContext.Boxes.FirstOrDefaultAsync(box => box.ID == request.ID, cancellationToken);

            if (true) //entity == null || entity.Name != request.Name
            {
                var Temp = new Box
                {
                    ID = Guid.NewGuid(),
                    width = Math.Round(request.width, 2),
                    height = Math.Round(request.height, 2),
                    depth = Math.Round(request.depth, 2),
                    weight = Math.Round(request.weight, 2),
                    expiration_date = request.expiration_date,
                    production_date = request.production_date,
                    PalletID = request.PalletID
                };

                await _dbContext.Boxes.AddAsync(Temp, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Temp.ID;
            }
            else
            {               
                throw new EntityAlreadyExistException(nameof(Box), request.ID);
            }
        }
    }
}
