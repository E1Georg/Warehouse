using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Warehouse.Application.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Warehouse.Application.Pallets.Queries.GetPalletList
{
    public class GetPalletListQueryHandler : IRequestHandler<GetPalletListQuery, PalletListVm>
    {
        private readonly IWarehouseDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetPalletListQueryHandler(IWarehouseDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PalletListVm> Handle(GetPalletListQuery request, CancellationToken cancellationToken)
        {
            var palletsQuery = await _dbContext.Pallets
                .ProjectTo<PalletLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PalletListVm { Pallets = palletsQuery };
        }
    }
}
