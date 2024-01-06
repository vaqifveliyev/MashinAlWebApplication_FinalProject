using MashinAl.Infastructure.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MashinAl.Data.Persistences.Membership
{
    internal class MashinAlUserEntityConfiguration : IEntityTypeConfiguration<MashinAlUser>
    {
        public void Configure(EntityTypeBuilder<MashinAlUser> builder)
        {

            builder.ToTable("Users", "Membership");
        }
    }
}
