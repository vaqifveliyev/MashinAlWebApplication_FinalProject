using MashinAl.Business.Modules.AccountModule.Commands.EmailConfirmCommand;
using MashinAl.Business.Modules.AccountModule.Commands.RegisterCommand;
using MashinAl.Business.Modules.AccountModule.Commands.SigninCommand;
using MashinAl.Business.Modules.PlateModule.Queries.PlateGetAllByUserQuery;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Profile(PlateGetAllByUserRequest request)
        {
            var data = await mediator.Send(request);
            return View(data);
        }

        [AllowAnonymous]
        [Route("/signin.html")]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/signin.html")]
        public async Task<IActionResult> SignIn(SigninRequest request)
        {
            await mediator.Send(request);

            var callback = Request.Query["ReturnUrl"];

            if (!string.IsNullOrWhiteSpace(callback))
            {
                return Redirect(callback);
            }

            return RedirectToAction("index", "home");
        }

        [AllowAnonymous]
        [Route("/register.html")]

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/register.html")]

        public async Task<IActionResult> Register(RegisterRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(SignIn));
        }

        [AllowAnonymous]
        [Route("/register-complete.html")]

        public async Task<IActionResult> EmailConfirm(EmailConfirmRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(SignIn));
        }

        [Route("/logout.html")]
        public async Task<IActionResult> Logout()
        {
            await Request.HttpContext.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [Route("/accessdenied.html")]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }



    }
}
