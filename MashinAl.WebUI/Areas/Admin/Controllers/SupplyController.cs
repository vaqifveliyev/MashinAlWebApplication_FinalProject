using MashinAl.Business.Modules.SupplyModule.Commands.SupplyAddCommand;
using MashinAl.Business.Modules.SupplyModule.Commands.SupplyEditCommand;
using MashinAl.Business.Modules.SupplyModule.Commands.SupplyRemoveCommand;
using MashinAl.Business.Modules.SupplyModule.Queries.SupplyGetAllQuery;
using MashinAl.Business.Modules.SupplyModule.Queries.SupplyGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SupplyController : Controller
    {
        private readonly IMediator mediator;

        
        public SupplyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize("admin.supply.index")]
        public async Task<IActionResult> Index(SupplyGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [Authorize("admin.supply.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize("admin.supply.create")]
        public async Task<IActionResult> Create(SupplyAddRequest request)
        {
            await mediator.Send(request);

            return Json(new
            {
                success = true,
                message = "Təchizat uğurla əlavə edildi!"
            });
        }

        [Authorize("admin.supply.edit")]
        public async Task<IActionResult> Edit(SupplyGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        [Authorize("admin.supply.edit")]
        public async Task<IActionResult> Edit(SupplyEditRequest request)
        {
            var response = await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [Authorize("admin.supply.details")]
        public async Task<IActionResult> Details(SupplyGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);

        }

        [HttpPost]
        [Authorize("admin.supply.delete")]
        public async Task<IActionResult> Delete(SupplyRemoveRequest request, SupplyGetAllRequest response)
        {
            await mediator.Send(request);

            var bantypes = await mediator.Send(response);

            return PartialView("_Body", bantypes);
        }
    }
}
