using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Warehouse.Application.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Warehouse.Application.Boxes.Queries.GetBoxList
{
    public class GetBoxListQueryHandler : IRequestHandler<GetBoxListQuery, BoxListVm>
    {
        private readonly IWarehouseDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBoxListQueryHandler(IWarehouseDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BoxListVm> Handle(GetBoxListQuery request, CancellationToken cancellationToken)
        {
            var boxesQuery = await _dbContext.Boxes
                .ProjectTo<BoxLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new BoxListVm { Boxes = boxesQuery };
        }
    }
}
