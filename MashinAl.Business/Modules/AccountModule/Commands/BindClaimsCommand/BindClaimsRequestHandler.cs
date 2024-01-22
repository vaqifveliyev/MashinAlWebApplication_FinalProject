using MashinAl.Data.Persistences;
using MashinAl.Infastructure.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MashinAl.Business.Modules.AccountModule.Commands.BindClaimsCommand
{
    internal class BindClaimsRequestHandler : IRequestHandler<BindClaimsRequest>
    {
        private readonly DataContext db;
        private readonly UserManager<MashinAlUser> userManager;

        public BindClaimsRequestHandler(DataContext db, UserManager<MashinAlUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        public async Task Handle(BindClaimsRequest request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(request.Identity.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value);

            var user = await db.Set<MashinAlUser>().FirstOrDefaultAsync(m => m.Id == userId, cancellationToken);



            request.Identity.AddClaim(new Claim(ClaimTypes.GivenName, $"{user.Name} {user.Surname}"));



            request.Identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            request.Identity.AddClaim(new Claim(ClaimTypes.Surname, user.Surname));
            request.Identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            request.Identity.AddClaim(new Claim(ClaimTypes.MobilePhone, user.PhoneNumber));


            var roles = await userManager.GetRolesAsync(user);

            foreach (var roleName in roles)
            {
                request.Identity.AddClaim(new Claim(ClaimTypes.Role, roleName));
            }

            var claims = await (from uc in db.Set<MashinAlUserClaim>()
                                where uc.UserId == userId && uc.ClaimValue.Equals("1")
                                select uc.ClaimType)
                                .Union(from rc in db.Set<MashinAlRoleClaim>()
                                       join ur in db.Set<MashinAlUserRole>() on rc.RoleId equals ur.RoleId
                                       where ur.UserId == userId && rc.ClaimValue.Equals("1")
                                       select rc.ClaimType)
                                .Distinct()
                                .ToArrayAsync(cancellationToken);

            foreach (var claimName in claims)
            {
                request.Identity.AddClaim(new Claim(claimName, "1"));
            }


        }
    }
}
