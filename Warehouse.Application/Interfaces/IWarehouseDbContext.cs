using Microsoft.EntityFrameworkCore;
using Warehouse.Domain;


namespace Warehouse.Application.Interfaces
{
    public interface IWarehouseDbContext
    {
        DbSet<Box> Boxes { get; set; }
        DbSet<Pallet> Pallets { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
