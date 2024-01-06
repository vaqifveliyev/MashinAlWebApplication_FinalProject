using MashinAl.Infastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MashinAl.Data.Persistences.Configurations
{
    internal class CarImageEntityConfiguration : IEntityTypeConfiguration<CarImage>
    {
        public void Configure(EntityTypeBuilder<CarImage> builder)
        {
            builder.Property(m => m.Id).UseIdentityColumn(1, 1);
            builder.Property(m => m.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(m => m.IsMain).IsRequired().HasColumnType("bit");
            builder.Property(m => m.CarId).IsRequired().HasColumnType("int");

            builder.HasKey(m => m.Id);
            builder.ToTable("CarImages");
        }
    }
}
