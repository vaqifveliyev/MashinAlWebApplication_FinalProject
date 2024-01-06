using MashinAl.Business.Modules.CarStatusModule.Commands.CarStatusAddCommand;
using MashinAl.Business.Modules.CarStatusModule.Commands.CarStatusEditCommand;
using MashinAl.Business.Modules.CarStatusModule.Commands.CarStatusRemoveCommand;
using MashinAl.Business.Modules.CarStatusModule.Queries.CarStatusGetAllQuery;
using MashinAl.Business.Modules.CarStatusModule.Queries.CarStatusGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarStatusController : Controller
    {
        private readonly IMediator mediator;

        
        public CarStatusController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize("admin.carstatus.index")]
        public async Task<IActionResult> Index(CarStatusGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [Authorize("admin.carstatus.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize("admin.carstatus.create")]
        public async Task<IActionResult> Create(CarStatusAddRequest request)
        {
            await mediator.Send(request);

            return Json(new
            {
                success = true,
                message = "Vəziyyət növü uğurla əlavə edildi!"
            });
        }

        [Authorize("admin.carstatus.edit")]
        public async Task<IActionResult> Edit(CarStatusGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        [Authorize("admin.carstatus.edit")]
        public async Task<IActionResult> Edit(CarStatusEditRequest request)
        {
            var response = await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [Authorize("admin.carstatus.details")]
        public async Task<IActionResult> Details(CarStatusGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);

        }

        [HttpPost]
        [Authorize("admin.carstatus.delete")]
        public async Task<IActionResult> Delete(CarStatusRemoveRequest request, CarStatusGetAllRequest response)
        {
            await mediator.Send(request);

            var bantypes = await mediator.Send(response);

            return PartialView("_Body", bantypes);
        }
    }
}
