using MashinAl.Business.Modules.AccountModule.Commands.DealerEdiCommand;
using MashinAl.Business.Modules.AccountModule.Commands.UserAddBalanceCommand;
using MashinAl.Business.Modules.AccountModule.Queries.GetDealerProfileQuery;
using MashinAl.Business.Modules.CarModule.Queries.CarGetAllByUserQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Areas.Dealership.Controllers
{
    [Area("Dealership")]
    public class DashboardController : Controller
    {
        private readonly IMediator mediator;

        public DashboardController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [Authorize("dealership.dashboard.index")]
        public async Task<IActionResult> Index(GetDealerProfileRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [Authorize("dealership.dashboard.addbalance")]
        public IActionResult AddBalance()
        {
            return View();
        }

        [HttpPost]
        [Authorize("dealership.dashboard.addbalance")]
        public async Task<IActionResult> AddBalance(UserAddBalanceRequest request)
        {
            await mediator.Send(request);
            return Redirect(nameof(Index));
        }

        [Authorize("dealership.dashboard.editprofile")]
        public async Task<IActionResult> EditProfile(GetDealerProfileRequest request)
        {
            var data = await mediator.Send(request);
            return View(data);
        }

        [HttpPost]
        [Authorize("dealership.dashboard.editprofile")]
        public async Task<IActionResult> EditProfile(DealerEditRequest request)
        {
            await mediator.Send(request);
            return Redirect(nameof(Index));
        }

        [Authorize("dealership.dashboard.cars")]
        public async Task<IActionResult> Cars(CarGetAllByUserPagedRequest request)
        {
            var data = await mediator.Send(request);
            return View(data);
        }
    }
}
