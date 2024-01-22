using MashinAl.Infastructure.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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
                throw new UserNotFoundException(request.UserName);

            var checkResult = await signInManager.CheckPasswordSignInAsync(user, request.Password, true);

            if (!checkResult.Succeeded)
                throw new InvalidCredentialsException();

            if (!user.EmailConfirmed)
                throw new EmailNotVerifiedException(request.UserName);

            var validationResult = new SigninRequestValidator().Validate(request);

            if (!validationResult.IsValid)
            {
                var errorMessages = string.Join(Environment.NewLine, validationResult.Errors.Select(error => error.ErrorMessage));
                throw new ValidationException(errorMessages);
            }

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
            if (string.IsNullOrWhiteSpace(userName))
            {
                // Handle null or empty userName as needed, e.g., return null or throw an exception.
                // For now, I'll return null.
                return null;
            }

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
