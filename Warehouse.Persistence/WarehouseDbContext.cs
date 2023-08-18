using Warehouse.Domain;
using Warehouse.Application.Interfaces;
using Warehouse.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;


namespace Warehouse.Persistence
{
    public class WarehouseDbContext : DbContext, IWarehouseDbContext
    {
        public DbSet<Box> Boxes { get; set; }
        public DbSet<Pallet> Pallets { get; set; }
        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BoxConfiguration());
            builder.ApplyConfiguration(new PalletConfiguration());

            builder.Entity<Box>()
            .HasOne<Pallet>(p => p.Pallet)
            .WithMany(t => t.Boxes)
            .HasForeignKey(p => p.PalletID)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }
    }
}
