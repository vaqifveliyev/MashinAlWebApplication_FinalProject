using MashinAl.Business.Modules.FuelTypeModule.Commands.FuelTypeAddCommand;
using MashinAl.Business.Modules.FuelTypeModule.Commands.FuelTypeEditCommand;
using MashinAl.Business.Modules.FuelTypeModule.Commands.FuelTypeRemoveCommand;
using MashinAl.Business.Modules.FuelTypeModule.Queries.FuelTypeGetAllQuery;
using MashinAl.Business.Modules.FuelTypeModule.Queries.FuelTypeGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FuelTypeController : Controller
    {
        private readonly IMediator mediator;

        
        public FuelTypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize("admin.fueltype.index")]
        public async Task<IActionResult> Index(FuelTypeGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [Authorize("admin.fueltype.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize("admin.fueltype.create")]
        public async Task<IActionResult> Create(FuelTypeAddRequest request)
        {
            await mediator.Send(request);

            return Json(new
            {
                success = true,
                message = "Yanacaq növü uğurla əlavə edildi!"
            });
        }

        [Authorize("admin.fueltype.edit")]
        public async Task<IActionResult> Edit(FuelTypeGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        [Authorize("admin.fueltype.edit")]
        public async Task<IActionResult> Edit(FuelTypeEditRequest request)
        {
            var response = await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [Authorize("admin.fueltype.details")]
        public async Task<IActionResult> Details(FuelTypeGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);

        }

        [HttpPost]
        [Authorize("admin.fueltype.delete")]
        public async Task<IActionResult> Delete(FuelTypeRemoveRequest request, FuelTypeGetAllRequest response)
        {
            await mediator.Send(request);

            var bantypes = await mediator.Send(response);

            return PartialView("_Body", bantypes);
        }
    }
}
