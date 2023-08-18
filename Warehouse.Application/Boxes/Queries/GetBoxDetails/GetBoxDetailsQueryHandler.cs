using Warehouse.Application.Interfaces;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Common.Exceptions;
using Warehouse.Domain;


namespace Warehouse.Application.Boxes.Queries.GetBoxDetails
{
    public class GetBoxDetailsQueryHandler : IRequestHandler<GetBoxDetailsQuery, BoxDetailsVm>
    {
        private readonly IWarehouseDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBoxDetailsQueryHandler(IWarehouseDbContext dbContext, IMapper mapper)
        => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<BoxDetailsVm> Handle(GetBoxDetailsQuery request, CancellationToken cancellationToken)
        {
            Box? entity = null;

            if (request.ID != Guid.Empty)
                entity = await _dbContext.Boxes.FirstOrDefaultAsync(box => box.ID == request.ID, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Box), request.ID);

            var result = _mapper.Map<BoxDetailsVm>(entity); 
            return result;
        }
    }
}
