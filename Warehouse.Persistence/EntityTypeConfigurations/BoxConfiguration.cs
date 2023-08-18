using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain;


namespace Warehouse.Persistence.EntityTypeConfigurations
{
    public class BoxConfiguration : IEntityTypeConfiguration<Box>
    {
        public void Configure(EntityTypeBuilder<Box> builder)
        {
            builder.HasKey(box => box.ID);
            builder.HasIndex(box => box.ID).IsUnique();

            builder.Property(box => box.ID).IsRequired();
            builder.Property(box => box.width).IsRequired();
            builder.Property(box => box.height).IsRequired();
            builder.Property(box => box.depth).IsRequired();
            builder.Property(box => box.weight).IsRequired();
            builder.Property(box => box.PalletID).IsRequired();
            builder.Property(box => box.expiration_date).IsRequired().HasColumnType("date");
            builder.Property(box => box.production_date).IsRequired().HasColumnType("date");          
        }
    }
}