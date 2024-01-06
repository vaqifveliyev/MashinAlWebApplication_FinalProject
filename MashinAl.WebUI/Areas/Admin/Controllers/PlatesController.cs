using MashinAl.Business.Modules.CityModule.Queries.CityGetAllQuery;
using MashinAl.Business.Modules.PlateModule.Commands.PlateEditCommand;
using MashinAl.Business.Modules.PlateModule.Commands.PlatePublishCommand;
using MashinAl.Business.Modules.PlateModule.Commands.PlateRejectCommand;
using MashinAl.Business.Modules.PlateModule.Commands.PlateRemoveCommand;
using MashinAl.Business.Modules.PlateModule.Queries.PlateGetAllQuery;
using MashinAl.Business.Modules.PlateModule.Queries.PlateGetByIdQuery;
using MashinAl.Business.Modules.RegionModule.Queries.RegionGetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MashinAl.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PlatesController : Controller
    {
        private readonly IMediator mediator;

        public PlatesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize("admin.plates.index")]
        public async Task<IActionResult> Index(PlateGetAllRequest request)
        {
            var data = await mediator.Send(request);
            return View(data);
        }

        [Authorize("admin.plates.details")]
        public async Task<IActionResult> Details(PlateGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        [Authorize("admin.plates.publish")]
        public async Task<IActionResult> Publish(PlatePublishRequest request)
        {
            await mediator.Send(request);

            return Json(new
            {
                success = true,
                message = "Qeydiyyat nişanı elanı təsdiqləndi!"
            });
        }

        [HttpPost]
        [Authorize("admin.plates.reject")]
        public async Task<IActionResult> Reject(PlateRejectRequest request)
        {
            await mediator.Send(request);

            return Json(new
            {
                success = true,
                message = "Qeydiyyat nişanı elanı imtina edildi!"
            });
        }

        [HttpPost]
        [Authorize("admin.plates.delete")]
        public async Task<IActionResult> Delete(PlateRemoveRequest request, PlateGetAllRequest response)
        {
            await mediator.Send(request);
            var data = await mediator.Send(response);
            return PartialView("_Body", data);
        }

        [Authorize("admin.plates.edit")]
        public async Task<IActionResult> Edit(PlateGetByIdRequest request)
        {

            ViewBag.RegionId = new SelectList(await mediator.Send(new RegionGetAllRequest()), "Id", "Title");
            ViewBag.CityId = new SelectList(await mediator.Send(new CityGetAllRequest()), "Id", "Name");

            var response = await mediator.Send(request);

            return View(response);
        }

        [HttpPost]
        [Authorize("admin.plates.edit")]
        public async Task<IActionResult> Edit(PlateEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }


    }
}
