using MashinAl.Infastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MashinAl.Data.Persistences.Configurations
{
    internal class PlateEntityConfiguration : IEntityTypeConfiguration<Plate>
    {
        public void Configure(EntityTypeBuilder<Plate> builder)
        {
            builder.Property(m => m.Id).UseIdentityColumn(1, 1);
            builder.Property(m => m.RegionId).HasColumnType("int").IsRequired();
            builder.Property(m => m.FirstLetter).HasColumnType("varchar").IsRequired();
            builder.Property(m => m.SecondLetter).HasColumnType("varchar").IsRequired();
            builder.Property(m => m.PlateNumber).HasColumnType("nvarchar").HasMaxLength(4).IsRequired();
            builder.Property(m => m.CityId).HasColumnType("int").IsRequired();
            builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.Property(m => m.Email).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.Property(m => m.Phone).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.Property(m => m.Description).HasColumnType("nvarchar").HasMaxLength(255);
            builder.Property(m => m.CreatedAt).HasColumnType("datetime");
            builder.Property(m => m.PublishedAt).HasColumnType("datetime");
            builder.Property(m => m.IsAccepted).HasColumnType("bit");
            builder.Property(m => m.IsRejected).HasColumnType("bit");
            builder.Property(m => m.CreatedBy).HasColumnType("int").IsRequired();

            builder.HasOne<Region>()
              .WithMany()
              .HasForeignKey(m => m.RegionId)
              .HasPrincipalKey(m => m.Id)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasKey(m => m.Id);
            builder.ToTable("Plates");

        }
    }
}
