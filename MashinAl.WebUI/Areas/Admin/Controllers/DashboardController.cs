using MashinAl.Business.Modules.DashboardModule.Queries.GetCountQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IMediator mediator;

        public DashboardController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize("admin.dashboard.index")]
        public async Task<IActionResult> Index(GetCountRequest request)
        {
            var data = await mediator.Send(request);
            return View(data);
        }
    }
}
