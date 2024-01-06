using MashinAl.Infastructure.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MashinAl.Data.Persistences.Membership
{
    internal class MashinAlRoleClaimEntityConfiguration : IEntityTypeConfiguration<MashinAlRoleClaim>
    {
        public void Configure(EntityTypeBuilder<MashinAlRoleClaim> builder)
        {

            builder.ToTable("RolesClaims", "Membership");
        }
    }
}
