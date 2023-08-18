namespace Warehouse.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(WarehouseDbContext context)
        {
            // context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
