using MashinAl.Infastructure.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MashinAl.Data.Persistences.Membership
{
    internal class MashinAlUserTokenEntityConfiguration : IEntityTypeConfiguration<MashinAlUserToken>
    {
        public void Configure(EntityTypeBuilder<MashinAlUserToken> builder)
        {

            builder.ToTable("UserTokens", "Membership");
        }
    }
}
