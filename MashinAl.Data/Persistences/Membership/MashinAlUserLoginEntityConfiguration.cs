using MashinAl.Infastructure.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MashinAl.Data.Persistences.Membership
{
    internal class MashinAlUserLoginEntityConfiguration : IEntityTypeConfiguration<MashinAlUserLogin>
    {
        public void Configure(EntityTypeBuilder<MashinAlUserLogin> builder)
        {

            builder.ToTable("UserLogins", "Membership");
        }
    }
}
