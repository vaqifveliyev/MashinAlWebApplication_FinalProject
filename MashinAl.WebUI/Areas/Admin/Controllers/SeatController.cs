using MashinAl.Business.Modules.SeatsModule.Commands.SeatsAddCommand;
using MashinAl.Business.Modules.SeatsModule.Commands.SeatsEditCommand;
using MashinAl.Business.Modules.SeatsModule.Commands.SeatsRemoveCommand;
using MashinAl.Business.Modules.SeatsModule.Queries.SeatsGetAllQuery;
using MashinAl.Business.Modules.SeatsModule.Queries.SeatsGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SeatController : Controller
    {
        private readonly IMediator mediator;

        
        public SeatController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize("admin.seat.index")]
        public async Task<IActionResult> Index(SeatsGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [Authorize("admin.seat.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize("admin.seat.create")]
        public async Task<IActionResult> Create(SeatsAddRequest request)
        {
            await mediator.Send(request);

            return Json(new
            {
                success = true,
                message = "Yer sayı uğurla əlavə edildi!"
            });
        }

        [Authorize("admin.seat.edit")]
        public async Task<IActionResult> Edit(SeatsGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        [Authorize("admin.seat.edit")]
        public async Task<IActionResult> Edit(SeatsEditRequest request)
        {
            var response = await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [Authorize("admin.seat.details")]
        public async Task<IActionResult> Details(SeatsGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);

        }

        [HttpPost]
        [Authorize("admin.seat.delete")]
        public async Task<IActionResult> Delete(SeatsRemoveRequest request, SeatsGetAllRequest response)
        {
            await mediator.Send(request);

            var bantypes = await mediator.Send(response);

            return PartialView("_Body", bantypes);
        }
    }
}
