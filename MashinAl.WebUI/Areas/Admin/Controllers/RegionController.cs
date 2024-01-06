using MashinAl.Business.Modules.RegionModule.Commands.RegionAddCommand;
using MashinAl.Business.Modules.RegionModule.Commands.RegionEditCommand;
using MashinAl.Business.Modules.RegionModule.Commands.RegionRemoveCommand;
using MashinAl.Business.Modules.RegionModule.Queries.RegionGetAllQuery;
using MashinAl.Business.Modules.RegionModule.Queries.RegionGetByIdQuery;
using MashinAl.Business.Modules.SeatsModule.Queries.SeatsGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegionController : Controller
    {
        private readonly IMediator mediator;

        public RegionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize("admin.region.index")]
        public async Task<IActionResult> Index(RegionGetAllRequest request)
        {
            var data = await mediator.Send(request);
            return View(data);
        }

        [Authorize("admin.region.cretae")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize("admin.region.cretae")]
        public async Task<IActionResult> Create(RegionAddRequest request)
        {
            await mediator.Send(request);

            return Json(new
            {
                success = true,
                message = "Elan uğurla əlavə olundu"
            });
        }

        [Authorize("admin.region.edit")]
        public async Task<IActionResult> Edit(RegionGetByIdRequest request)
        {
            var data = await mediator.Send(request);
            return View(data);
        }

        [HttpPost]
        [Authorize("admin.region.edit")]
        public async Task<IActionResult> Edit(RegionEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [Authorize("admin.region.details")]
        public async Task<IActionResult> Details(RegionGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        [Authorize("admin.region.delete")]
        public async Task<IActionResult> Delete(RegionRemoveRequest request, RegionGetAllRequest response)
        {
            await mediator.Send(request);

            var models = await mediator.Send(response);

            return PartialView("_Body", models);
        }

    }
}
