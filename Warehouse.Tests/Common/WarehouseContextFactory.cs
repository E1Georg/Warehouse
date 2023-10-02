using Warehouse.Application;
using Warehouse.Domain;
using Warehouse.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Warehouse.Tests.Common
{
    public class WarehouseContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid EntityIdForDelete = Guid.NewGuid();
        public static Guid EntityIdForUpdate = Guid.NewGuid();

        public static WarehouseDbContext Create() 
        {
            var options = new DbContextOptionsBuilder<WarehouseDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new WarehouseDbContext(options);
            context.Database.EnsureCreated();

            context.Pallets.AddRange(
                new Pallet
                {
                    ID = Guid.Parse(Guid.NewGuid().ToString()),
                },
                new Pallet
                {

                });

            context.Boxes.AddRange();

            context.SaveChanges();
            return context;
        }

        public static void Destroy(WarehouseDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

    }
}
