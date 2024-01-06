using MashinAl.Business.Modules.MarkasModule.Commands.MarkaAddCommand;
using MashinAl.Business.Modules.MarkasModule.Commands.MarkaEditCommand;
using MashinAl.Business.Modules.MarkasModule.Commands.MarkaRemoveCommand;
using MashinAl.Business.Modules.MarkasModule.Queries.MarkaGetAllQuery;
using MashinAl.Business.Modules.MarkasModule.Queries.MarkaGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MarkaController : Controller
    {
        private readonly IMediator mediator;

        public MarkaController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [Authorize("admin.marka.index")]
        public async Task<IActionResult> Index(MarkaGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [Authorize("admin.marka.details")]
        public async Task<IActionResult> Details(MarkaGetByIdRequest request)
        {
            var response = await mediator.Send(request);

            return View(response);
        }

        [Authorize("admin.marka.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize("admin.marka.create")]
        public async Task<IActionResult> Create(MarkaAddRequest request)
        {
            await mediator.Send(request);
            
            return Json(new
            {
                success = true,
                message = "Marka uğurla əlavə edildi!"
            });
        }

        [Authorize("admin.marka.edit")]
        public async Task<IActionResult> Edit(MarkaGetByIdRequest request)
        {

            var response = await mediator.Send(request);

            return View(response);
        }

        [HttpPost]
        [Authorize("admin.marka.edit")]
        public async Task<IActionResult> Edit(MarkaEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize("admin.marka.delete")]
        public async Task<IActionResult> Delete(MarkaRemoveRequest request, MarkaGetAllRequest response)
        {
            await mediator.Send(request);

            var markas =  await mediator.Send(response);

            return PartialView("_Body", markas);
        } 
    }
}

