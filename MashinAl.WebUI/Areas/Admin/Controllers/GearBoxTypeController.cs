using MashinAl.Business.Modules.GearboxTypeModule.Commands.GearboxTypeAddCommand;
using MashinAl.Business.Modules.GearboxTypeModule.Commands.GearboxTypeEditCommand;
using MashinAl.Business.Modules.GearboxTypeModule.Commands.GearboxTypeRemoveCommand;
using MashinAl.Business.Modules.GearboxTypeModule.Queries.GearboxTypeGetAllQuery;
using MashinAl.Business.Modules.GearboxTypeModule.Queries.GearboxTypeGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GearBoxTypeController : Controller
    {
        private readonly IMediator mediator;

        
        public GearBoxTypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize("admin.gearboxtype.index")]
        public async Task<IActionResult> Index(GearboxTypeGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [Authorize("admin.gearboxtype.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize("admin.gearboxtype.create")]
        public async Task<IActionResult> Create(GearboxTypeAddRequest request)
        {
            await mediator.Send(request);

            return Json(new
            {
                success = true,
                message = "Ötürücü növü uğurla əlavə edildi!"
            });
        }

        [Authorize("admin.gearboxtype.edit")]
        public async Task<IActionResult> Edit(GearboxTypeGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        [Authorize("admin.gearboxtype.edit")]
        public async Task<IActionResult> Edit(GearboxTypeEditRequest request)
        {
            var response = await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [Authorize("admin.gearboxtype.details")]
        public async Task<IActionResult> Details(GearboxTypeGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);

        }

        [HttpPost]
        [Authorize("admin.gearboxtype.delete")]
        public async Task<IActionResult> Delete(GearboxTypeRemoveRequest request, GearboxTypeGetAllRequest response)
        {
            await mediator.Send(request);

            var bantypes = await mediator.Send(response);

            return PartialView("_Body", bantypes);
        }
    }
}
