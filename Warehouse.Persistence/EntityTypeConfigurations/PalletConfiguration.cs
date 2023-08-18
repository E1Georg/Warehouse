using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain;


namespace Warehouse.Persistence.EntityTypeConfigurations
{
    public class PalletConfiguration : IEntityTypeConfiguration<Pallet>
    {
        public void Configure(EntityTypeBuilder<Pallet> builder)
        {
            builder.HasKey(pallet => pallet.ID);
            builder.HasIndex(pallet => pallet.ID).IsUnique();
          
            builder.Property(pallet => pallet.ID).IsRequired();
            builder.Property(pallet => pallet.width).IsRequired();
            builder.Property(pallet => pallet.height).IsRequired();
            builder.Property(pallet => pallet.depth).IsRequired();
            builder.Property(pallet => pallet.weight).IsRequired();       
            builder.Property(pallet => pallet.expiration_date).IsRequired().HasColumnType("date"); 
        }
    }
}
