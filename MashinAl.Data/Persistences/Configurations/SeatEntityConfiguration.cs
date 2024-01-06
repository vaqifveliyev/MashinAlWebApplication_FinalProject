using MashinAl.Infastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MashinAl.Data.Persistences.Configurations
{
    internal class SeatEntityConfiguration : IEntityTypeConfiguration<Seats>
    {
        public void Configure(EntityTypeBuilder<Seats> builder)
        {
            builder.Property(m => m.Id).UseIdentityColumn(1, 1);
            builder.Property(m => m.SeatTitle).HasColumnType("int").HasMaxLength(2).IsRequired();

            builder.HasKey(m => m.Id);
            builder.ToTable("Seats");
        }
    }
}
