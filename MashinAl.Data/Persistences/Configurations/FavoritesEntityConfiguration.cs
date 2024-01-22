using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MashinAl.Data.Persistences.Configurations
{
    internal class FavoritesEntityConfiguration : IEntityTypeConfiguration<Favorites>
    {
        public void Configure(EntityTypeBuilder<Favorites> builder)
        {
            builder.Property(m => m.UserId).HasColumnType("int").IsRequired();
            builder.Property(m => m.CarId).HasColumnType("int").IsRequired();
            builder.Property(m => m.Quantity).HasColumnType("decimal").HasPrecision(18, 2).IsRequired();

            builder.HasKey(m => new { m.UserId, m.CarId });
            builder.ToTable("Favorites");

            builder.HasOne<Car>()
                .WithMany()
                .HasForeignKey(p => p.CarId)
                .HasPrincipalKey(m => m.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<MashinAlUser>()
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .HasPrincipalKey(m => m.Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
