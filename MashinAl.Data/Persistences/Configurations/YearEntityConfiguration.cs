using MashinAl.Infastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MashinAl.Data.Persistences.Configurations
{
    internal class YearEntityConfiguration : IEntityTypeConfiguration<Year>
    {
        public void Configure(EntityTypeBuilder<Year> builder)
        {
            builder.Property(m => m.Id).UseIdentityColumn(1, 1);
            builder.Property(m => m.YearTitle).HasColumnType("int").HasMaxLength(4).IsRequired();

            builder.HasKey(m => m.Id);
            builder.ToTable("Years");
        }
    }
}
