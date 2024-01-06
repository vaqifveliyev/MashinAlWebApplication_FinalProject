using MashinAl.Infastructure.Entities.Membership;
using MashinAl.Infastructure.Services.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Text;
using System.Web;
using System.Xml.Linq;

namespace MashinAl.Business.Modules.AccountModule.Commands.RegisterCommand
{
    internal class RegisterRequestHandler : IRequestHandler<RegisterRequest>
    {
        private readonly UserManager<MashinAlUser> userManager;
        private readonly RoleManager<MashinAlRole> roleManager;
        private readonly IEmailService emailService;
        private readonly IActionContextAccessor ctx;

        public RegisterRequestHandler(UserManager<MashinAlUser> userManager,
            RoleManager<MashinAlRole> roleManager,
            IEmailService emailService,
            IActionContextAccessor ctx)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.emailService = emailService;
            this.ctx = ctx;
        }
        public async Task Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            if (user != null)
            {
                throw new Exception($"{request.Email} user already taken!");
            }

            user = new MashinAlUser
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                EmailConfirmed = false
            };

            int? tryCount = null;

            string sanitizedFirstName = ReplaceSpecialCharacters(request.Name);
            string sanitizedSurname = ReplaceSpecialCharacters(request.Surname);

            while (true)
            {
                user.UserName = $"{sanitizedFirstName}.{sanitizedSurname}{(tryCount.HasValue ? tryCount.ToString() : "")}".ToLower();
                if (await userManager.FindByNameAsync(user.UserName) == null)
                    break;

                tryCount = (tryCount ?? 0) + 1;
            }

            var userCreateResult = await userManager.CreateAsync(user, request.Password);

            if (!userCreateResult.Succeeded)
            {
                var sb = new StringBuilder();

                foreach (var item in userCreateResult.Errors)
                {
                    sb.AppendLine($"{item.Code}: {item.Description}");
                }

                throw new Exception(sb.ToString());
            }


            string token = await userManager.GenerateEmailConfirmationTokenAsync(user);

            token = HttpUtility.UrlEncode(token);

            string url = $"{ctx.ActionContext.HttpContext.Request.Scheme}://{ctx.ActionContext.HttpContext.Request.Host}/register-complete.html?token={token}&email={user.Email}";

            //string message = $"Hörmətli {request.Name} {request.Surname}!<br>Qeydiyyatı tamamlamaq üçün <a href='{url}'>Buraya</a> klik edin!";


            string name = request.Name;
            string surname = request.Surname;
            string activationUrl = url;

            string htmlMessage = RegisterEmailTemplate.RegisterMessage(name, surname, activationUrl);

            await emailService.SendMailAsync(request.Email, "MashinAl | Qeydiyyat", htmlMessage);
        }

        private string ReplaceSpecialCharacters(string input)
        {
            // Define a dictionary for character replacements
            var characterReplacements = new Dictionary<char, char>
        {
            { 'ə', 'e' },
            { 'ü', 'u' },
            { 'ğ', 'g' },
            { 'ş', 's' },
            { 'ç', 'c' }
            // Add more replacements as needed
        };

            // Replace special characters
            foreach (var replacement in characterReplacements)
            {
                input = input.Replace(replacement.Key, replacement.Value);
            }

            return input;
        }


    }
}
