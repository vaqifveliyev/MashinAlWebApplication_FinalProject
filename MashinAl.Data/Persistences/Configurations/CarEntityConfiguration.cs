using MashinAl.Infastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MashinAl.Data.Persistences.Configurations
{
    internal class CarEntityConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(m => m.MarkaId).HasColumnType("int").IsRequired();
            builder.Property(m => m.ModelId).HasColumnType("int").IsRequired();
            builder.Property(m => m.YearId).HasColumnType("int").HasMaxLength(4).IsRequired();
            builder.Property(m => m.BanTypeId).HasColumnType("int").IsRequired();
            builder.Property(m => m.FuelTypeId).HasColumnType("int").IsRequired();
            builder.Property(m => m.GearboxId).HasColumnType("int").IsRequired();
            builder.Property(m => m.TransmissionId).HasColumnType("int").IsRequired();
            builder.Property(m => m.March).HasColumnType("int").IsRequired();
            builder.Property(m => m.ColorId).HasColumnType("int").IsRequired();
            builder.Property(m => m.SeatsId).HasColumnType("int").IsRequired();
            builder.Property(m => m.StatusId).HasColumnType("int").IsRequired();
            builder.Property(m => m.Price).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(m => m.Engine).HasColumnType("decimal").IsRequired();
            builder.Property(m => m.IsBarter).HasColumnType("bit");
            builder.Property(m => m.IsCredit).HasColumnType("bit");
            builder.Property(m => m.IsDealership).HasColumnType("bit");
            builder.Property(m => m.IsBoosted).HasColumnType("bit");
            builder.Property(m => m.Description).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(m => m.Name).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(m => m.Email).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(m => m.Phone).HasColumnType("nvarchar").HasMaxLength(10).IsRequired();
            builder.Property(m => m.SellCityId).HasColumnType("int").HasMaxLength(20).IsRequired();
            builder.Property(m => m.CreatedAt).HasColumnType("datetime");
            builder.Property(m => m.PublishedAt).HasColumnType("datetime");
            builder.Property(m => m.IsAccepted).HasColumnType("bit");
            builder.Property(m => m.IsRejected).HasColumnType("bit");
            builder.Property(m => m.CreatedBy).HasColumnType("int").IsRequired();
            builder.Property(m => m.ViewCount).HasColumnType("int").IsRequired().HasDefaultValue(0);

            builder.HasKey(m => m.Id);
            builder.ToTable("Cars");

            builder.HasOne<Marka>()
                .WithMany()
                .HasForeignKey(m => m.MarkaId)
                .HasPrincipalKey(m => m.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Model>()
                .WithMany()
                .HasForeignKey(m => m.ModelId)
                .HasPrincipalKey(m => m.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Color>()
                .WithMany()
                .HasForeignKey(m => m.ColorId)
                .HasPrincipalKey(m => m.Id)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
