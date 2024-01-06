using MashinAl.Infastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MashinAl.Data.Persistences.Configurations
{
    internal class CarStatusEntityConfiguration : IEntityTypeConfiguration<CarStatus>
    {
        public void Configure(EntityTypeBuilder<CarStatus> builder)
        {
            builder.Property(m => m.Id).UseIdentityColumn(1, 1);
            builder.Property(m => m.Title).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();


            builder.HasKey(m => m.Id);
            builder.ToTable("CarStatus");
        }
    }
}
