using MashinAl.Business.Modules.ColorModule.Commands.ColorAddCommand;
using MashinAl.Business.Modules.ColorModule.Commands.ColorEditCommand;
using MashinAl.Business.Modules.ColorModule.Commands.ColorRemoveCommand;
using MashinAl.Business.Modules.ColorModule.Queries.ColorGetAllQuery;
using MashinAl.Business.Modules.ColorModule.Queries.ColorGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorController : Controller
    {
        private readonly IMediator mediator;

        public ColorController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize("admin.color.index")]
        public async Task<IActionResult> Index(ColorGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [Authorize("admin.color.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize("admin.color.create")]
        public async Task<IActionResult> Create(ColorAddRequest request)
        {
            await mediator.Send(request);

            return Json(new
            {
                success = true,
                message = "Rəng uğurla əlavə edildi!"
            });
        }

        [Authorize("admin.color.edit")]
        public async Task<IActionResult> Edit(ColorGetByIdRequest request)
        {
            var response = await mediator.Send(request);

            return View(response);
        }

        [HttpPost]
        [Authorize("admin.color.edit")]
        public async Task<IActionResult> Edit(ColorEditRequest request)
        {
            await mediator.Send(request);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize("admin.color.delete")]
        public async Task<IActionResult> Delete(ColorRemoveRequest request, ColorGetAllRequest response)
        {
            await mediator.Send(request);

            var colors = await mediator.Send(response);

            return PartialView("_Body", colors);
        }


        [Authorize("admin.color.details")]
        public async Task<IActionResult> Details(ColorGetByIdRequest request)
        {
            var response = await mediator.Send(request);

            return View(response);
        }
    }
}
