using MashinAl.Business.Modules.AccountModule.Commands.EmailConfirmCommand;
using MashinAl.Business.Modules.AccountModule.Commands.RegisterCommand;
using MashinAl.Business.Modules.AccountModule.Commands.RegisterDealerCommand;
using MashinAl.Business.Modules.AccountModule.Commands.SigninCommand;
using MashinAl.Business.Modules.AccountModule.Commands.UserAddBalanceCommand;
using MashinAl.Business.Modules.AccountModule.Queries.GetAccountBalanceQuery;
using MashinAl.Business.Modules.CarModule.Commands.CarBoostCommand;
using MashinAl.Business.Modules.CarModule.Commands.CarRemoveCommand;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MashinAl.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Profile(GetUserBalanceRequest request)
        {
            var data = await mediator.Send(request);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCar(CarRemoveRequest request)
        {
            await mediator.Send(request);
            return Json(new
            {
                success = true,
                message = "Avtomobil elanınız uğurla silindi!"
            });
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
            try
            {
                var validator = new SigninRequestValidator();
                var validationResult = await validator.ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }

                    return View("SignIn", request);
                }

                await mediator.Send(request);

                var callback = Request.Query["ReturnUrl"];

                if (!string.IsNullOrWhiteSpace(callback))
                {
                    return Redirect(callback);
                }

                return RedirectToAction("index", "home");
            }
            catch (UserNotFoundException ex)
            {
                ModelState.AddModelError("UserName", ex.Message);
            }
            catch (InvalidCredentialsException ex)
            {
                ModelState.AddModelError("Password", ex.Message);
            }
            catch (EmailNotVerifiedException ex)
            {
                ModelState.AddModelError("UserName", ex.Message);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View("SignIn", request);
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

        [AllowAnonymous]
        public IActionResult DealershipRegister()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> DealershipRegister(RegisterDealerRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(SignIn));
        }

        [HttpPost]
        public async Task<IActionResult> BoostCar(CarBoostRequest request)
        {
            await mediator.Send(request);

            return RedirectToAction(nameof(Profile));
        }

        public IActionResult AddBalance()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBalance(UserAddBalanceRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Profile));
        }

    }
}
