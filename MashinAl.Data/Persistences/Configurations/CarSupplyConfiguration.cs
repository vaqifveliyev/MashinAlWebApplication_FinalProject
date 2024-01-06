using MashinAl.Infastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MashinAl.Data.Persistences.Configurations
{
    internal class CarSupplyConfiguration : IEntityTypeConfiguration<CarSupply>
    {
        public void Configure(EntityTypeBuilder<CarSupply> builder)
        {
            builder.Property(m => m.CarId).HasColumnType("int");
            builder.Property(m => m.SupplyId).HasColumnType("int");

            builder.HasKey(m => new
            {
                m.CarId,
                m.SupplyId
            });

            builder.ToTable("CarSupplies");

            builder.HasOne<Supply>()
            .WithMany()
            .HasForeignKey(m => m.SupplyId)
            .HasPrincipalKey(m => m.Id)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
