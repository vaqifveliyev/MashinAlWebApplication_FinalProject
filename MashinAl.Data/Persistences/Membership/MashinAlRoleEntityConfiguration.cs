using MashinAl.Infastructure.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MashinAl.Data.Persistences.Membership
{
    internal class MashinAlRoleEntityConfiguration : IEntityTypeConfiguration<MashinAlRole>
    {
        public void Configure(EntityTypeBuilder<MashinAlRole> builder)
        {

            builder.ToTable("Roles", "Membership");
        }
    }
}
