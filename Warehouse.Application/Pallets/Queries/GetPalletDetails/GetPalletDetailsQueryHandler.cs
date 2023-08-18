using Warehouse.Application.Interfaces;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Common.Exceptions;
using Warehouse.Domain;


namespace Warehouse.Application.Pallets.Queries.GetPalletDetails
{
    public class GetPalletDetailsQueryHandler : IRequestHandler<GetPalletDetailsQuery, PalletDetailsVm>
    {
        private readonly IWarehouseDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPalletDetailsQueryHandler(IWarehouseDbContext dbContext, IMapper mapper)
        => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PalletDetailsVm> Handle(GetPalletDetailsQuery request, CancellationToken cancellationToken)
        {
            Pallet? entity = null;

            if (request.ID != Guid.Empty)
                entity = await _dbContext.Pallets.FirstOrDefaultAsync(pallet => pallet.ID == request.ID, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Pallet), request.ID);

            var result = _mapper.Map<PalletDetailsVm>(entity); 
            return result;
        }
    }
}
