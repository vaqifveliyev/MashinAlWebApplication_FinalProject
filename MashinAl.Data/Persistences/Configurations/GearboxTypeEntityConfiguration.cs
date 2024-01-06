using MashinAl.Infastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MashinAl.Data.Persistences.Configurations
{
    internal class GearboxTypeEntityConfiguration : IEntityTypeConfiguration<GearboxType>
    {
        public void Configure(EntityTypeBuilder<GearboxType> builder)
        {
            builder.Property(m => m.Id).UseIdentityColumn(1, 1);
            builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();

            builder.HasKey(m => m.Id);
            builder.ToTable("GearboxTypes");
        }
    }
}
