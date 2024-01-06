using MashinAl.Infastructure.Entities.Membership;
using MashinAl.Infastructure.Services.Abstracts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Data.Persistences
{
    public class DataContext : IdentityDbContext<MashinAlUser, MashinAlRole, int, MashinAlUserClaim, MashinAlUserRole, MashinAlUserLogin, MashinAlRoleClaim, MashinAlUserToken>
    {

        public DataContext(DbContextOptions options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
