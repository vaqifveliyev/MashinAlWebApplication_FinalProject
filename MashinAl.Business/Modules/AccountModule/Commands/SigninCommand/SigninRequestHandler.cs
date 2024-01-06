using MashinAl.Infastructure.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MashinAl.Business.Modules.AccountModule.Commands.SigninCommand
{
    internal class SigninRequestHandler : IRequestHandler<SigninRequest> 
    {
        private readonly UserManager<MashinAlUser> userManager;
        private readonly SignInManager<MashinAlUser> signInManager;
        private readonly IActionContextAccessor ctx;

        public SigninRequestHandler(UserManager<MashinAlUser> userManager, SignInManager<MashinAlUser> signInManager, IActionContextAccessor ctx)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.ctx = ctx;
        }

        public async Task Handle(SigninRequest request, CancellationToken cancellationToken)
        {
            var user = await FindUserAsync(request.UserName);

            if (user == null)
                throw new Exception($"{request.UserName} user not found!");

            var checkResult = await signInManager.CheckPasswordSignInAsync(user, request.Password, true);

            if (!checkResult.Succeeded)
                throw new Exception($"Username, Email, Phone Number, or Password is incorrect!");

            if (!user.EmailConfirmed)
                throw new Exception($"{request.UserName} is not verified!");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                
            };

            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

            await ctx.ActionContext.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(10)
            });
        }

        private async Task<MashinAlUser> FindUserAsync(string userName)
        {
            // Check userName if email
            var user = await userManager.FindByEmailAsync(userName);

            // If not found, check userName is a username
            if (user == null)
                user = await userManager.FindByNameAsync(userName);

            // If not found, check if the userName is a phone number
            if (user == null)
                user = await userManager.Users.SingleOrDefaultAsync(u => u.PhoneNumber == userName);

            return user;
        }
    }
}
