using Warehouse.Application.Common.Exceptions;
using Warehouse.Application.Interfaces;
using Warehouse.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Warehouse.Application.Pallets.Commands.ChangePalletWeigthAndExpirationDate
{
    public class ChangePalletCommandHandler : IRequestHandler<ChangePalletCommand, Unit>
    {
        private readonly IWarehouseDbContext _dbContext;
        public ChangePalletCommandHandler(IWarehouseDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(ChangePalletCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Pallets.FirstOrDefaultAsync(pallet => pallet.ID == request.ID, cancellationToken);

            if (entity == null || entity.ID != request.ID)
                throw new NotFoundException(nameof(Pallet), request.ID);
                        
            entity.weight = Math.Round(entity.weight + request.weight, 2);
       
                    
            if (entity.expiration_date == DateTime.MinValue || entity.expiration_date > request.expiration_date)
                entity.expiration_date = request.expiration_date;

            if (request.expiration_date == DateTime.MaxValue)
            {
                var tmpBoxes = _dbContext.Boxes.Where(box => box.PalletID == request.ID);
                DateTime tmpDate = DateTime.MaxValue;

                foreach (var item in tmpBoxes)
                    if (tmpDate < item.expiration_date)
                        tmpDate = item.expiration_date;

                if(tmpDate == DateTime.MaxValue)
                    tmpDate = DateTime.MinValue; //Если в паллете нет коробок, устанавливается стандартное значение времени для паллеты

                entity.expiration_date = tmpDate;
            }            

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
