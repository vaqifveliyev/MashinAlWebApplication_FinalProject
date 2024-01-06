using MashinAl.Business.Modules.TransmissionTypeModule.Commands.TransmissionTypeAddCommand;
using MashinAl.Business.Modules.TransmissionTypeModule.Commands.TransmissionTypeEditCommand;
using MashinAl.Business.Modules.TransmissionTypeModule.Commands.TransmissionTypeRemoveCommand;
using MashinAl.Business.Modules.TransmissionTypeModule.Queries.TransmissionTypeGetAllQuery;
using MashinAl.Business.Modules.TransmissionTypeModule.Queries.TransmissionTypeGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TransmissionTypeController : Controller
    {
        private readonly IMediator mediator;

        
        public TransmissionTypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize("admin.transmissiontype.index")]
        public async Task<IActionResult> Index(TransmissionTypeGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [Authorize("admin.transmissiontype.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize("admin.transmissiontype.create")]
        public async Task<IActionResult> Create(TransmissionTypeAddRequest request)
        {
            await mediator.Send(request);

            return Json(new
            {
                success = true,
                message = "Sürətlər qutusu növü uğurla əlavə edildi!"
            });
        }

        [Authorize("admin.transmissiontype.edit")]
        public async Task<IActionResult> Edit(TransmissionTypeGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        [Authorize("admin.transmissiontype.edit")]
        public async Task<IActionResult> Edit(TransmissionTypeEditRequest request)
        {
            var response = await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [Authorize("admin.transmissiontype.details")]
        public async Task<IActionResult> Details(TransmissionTypeGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);

        }

        [HttpPost]
        [Authorize("admin.transmissiontype.delete")]
        public async Task<IActionResult> Delete(TransmissionTypeRemoveRequest request, TransmissionTypeGetAllRequest response)
        {
            await mediator.Send(request);

            var transmissions = await mediator.Send(response);

            return PartialView("_Body", transmissions);
        }
    }
}
