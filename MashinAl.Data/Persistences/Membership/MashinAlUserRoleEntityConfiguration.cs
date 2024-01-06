using MashinAl.Infastructure.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MashinAl.Data.Persistences.Membership
{
    internal class MashinAlUserRoleEntityConfiguration : IEntityTypeConfiguration<MashinAlUserRole>
    {
        public void Configure(EntityTypeBuilder<MashinAlUserRole> builder)
        {

            builder.ToTable("UserRoles", "Membership");
        }
    }
}
