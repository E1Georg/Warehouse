using Warehouse.Application;
using Warehouse.Domain;
using Warehouse.Persistence;
using Microsoft.EntityFrameworkCore;
using Azure.Core;


namespace Warehouse.Tests.Common
{
    public class WarehouseContextFactory
    {
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
                    ID = new Guid("1a19c13d-cab0-467b-8776-423eaee61f2a"), //1a...
                    width = 1000,
                    height = 1000,
                    depth = 1000,
                    weight = 93,
                    expiration_date = new DateTime(2023, 8, 1).AddDays(100)
                },
                new Pallet
                {
                    ID = new Guid("2a19c13d-cab0-467b-8776-423eaee61f2a"), //2a....
                    width = 2000,
                    height = 2000,
                    depth = 2000,
                    weight = 97,
                    expiration_date = new DateTime(2023, 8, 1).AddDays(100)
                },
                new Pallet
                {
                    ID = new Guid("3a19c13d-cab0-467b-8776-423eaee61f2a"), //3a....
                    width = 3000,
                    height = 3000,
                    depth = 3000,
                    weight = 99,
                    expiration_date = new DateTime(2023, 8, 1).AddDays(100)
                },
                new Pallet
                {
                    ID = new Guid("4a19c13d-cab0-467b-8776-423eaee61f2a"),
                    width = 4000,
                    height = 4000,
                    depth = 4000,
                    weight = 67,
                    expiration_date = new DateTime(2023, 8, 1).AddDays(100)
                },
                new Pallet
                {
                    ID = new Guid("5a19c13d-cab0-467b-8776-423eaee61f2a"),
                    width = 5000,
                    height = 5000,
                    depth = 5000,
                    weight = 68,
                    expiration_date = new DateTime(2023, 8, 1).AddDays(100)
                });

            context.Boxes.AddRange(
                 new Box
                 {
                     ID = new Guid("1b19c13d-cab0-467b-8776-423eaee61f2a"), // 1b....
                     width = 100,
                     height = 100,
                     depth = 100,
                     weight = 31,
                     expiration_date = new DateTime(2023, 8, 1).AddDays(100),
                     production_date = new DateTime(2023, 8, 1),
                     PalletID = new Guid("1a19c13d-cab0-467b-8776-423eaee61f2a")
                 },
                 new Box
                 {
                     ID = new Guid("2b19c13d-cab0-467b-8776-423eaee61f2a"), // 2b....
                     width = 200,
                     height = 200,
                     depth = 200,
                     weight = 32,
                     expiration_date = new DateTime(2023, 8, 1).AddDays(100),
                     production_date = new DateTime(2023, 8, 1),
                     PalletID = new Guid("1a19c13d-cab0-467b-8776-423eaee61f2a")
                 },
                 new Box
                 {
                     ID = new Guid("3b19c13d-cab0-467b-8776-423eaee61f2a"), // 3b.....
                     width = 300,
                     height = 300,
                     depth = 300,
                     weight = 33,
                     expiration_date = new DateTime(2023, 8, 1).AddDays(100),
                     production_date = new DateTime(2023, 8, 1),
                     PalletID = new Guid("2a19c13d-cab0-467b-8776-423eaee61f2a")
                 },
                 new Box
                 {
                     ID = new Guid("4b19c13d-cab0-467b-8776-423eaee61f2a"),
                     width = 400,
                     height = 400,
                     depth = 400,
                     weight = 34,
                     expiration_date = new DateTime(2023, 8, 1).AddDays(100),
                     production_date = new DateTime(2023, 8, 1),
                     PalletID = new Guid("2a19c13d-cab0-467b-8776-423eaee61f2a")
                 },
                 new Box
                 {
                     ID = new Guid("5b19c13d-cab0-467b-8776-423eaee61f2a"),
                     width = 500,
                     height = 500,
                     depth = 500,
                     weight = 35,
                     expiration_date = new DateTime(2023, 8, 1).AddDays(100),
                     production_date = new DateTime(2023, 8, 1),
                     PalletID = new Guid("3a19c13d-cab0-467b-8776-423eaee61f2a")
                 },
                   new Box
                   {
                       ID = new Guid("6b19c13d-cab0-467b-8776-423eaee61f2a"),
                       width = 600,
                       height = 600,
                       depth = 600,
                       weight = 36,
                       expiration_date = new DateTime(2023, 8, 1).AddDays(100),
                       production_date = new DateTime(2023, 8, 1),
                       PalletID = new Guid("3a19c13d-cab0-467b-8776-423eaee61f2a")
                   },
                     new Box
                     {
                         ID = new Guid("7b19c13d-cab0-467b-8776-423eaee61f2a"),
                         width = 700,
                         height = 700,
                         depth = 700,
                         weight = 37,
                         expiration_date = new DateTime(2023, 8, 1).AddDays(100),
                         production_date = new DateTime(2023, 8, 1),
                         PalletID = new Guid("4a19c13d-cab0-467b-8776-423eaee61f2a")
                     },
                       new Box
                       {
                           ID = new Guid("8b19c13d-cab0-467b-8776-423eaee61f2a"),
                           width = 800,
                           height = 800,
                           depth = 800,
                           weight = 38,
                           expiration_date = new DateTime(2023, 8, 1).AddDays(100),
                           production_date = new DateTime(2023, 8, 1),
                           PalletID = new Guid("5a19c13d-cab0-467b-8776-423eaee61f2a")
                       });

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
