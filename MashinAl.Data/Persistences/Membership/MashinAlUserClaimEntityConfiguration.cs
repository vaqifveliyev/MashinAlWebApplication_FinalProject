using MashinAl.Infastructure.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MashinAl.Data.Persistences.Membership
{
    internal class MashinAlUserClaimEntityConfiguration : IEntityTypeConfiguration<MashinAlUserClaim>
    {
        public void Configure(EntityTypeBuilder<MashinAlUserClaim> builder)
        {

            builder.ToTable("UserClaim", "Membership");
        }
    }
}
