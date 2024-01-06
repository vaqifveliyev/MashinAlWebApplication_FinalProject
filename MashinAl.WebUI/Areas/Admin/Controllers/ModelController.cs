using MashinAl.Business.Modules.MarkasModule.Queries.MarkaGetAllQuery;
using MashinAl.Business.Modules.ModelModule.Commands.MarkaRemoveCommand;
using MashinAl.Business.Modules.ModelModule.Commands.ModelAddCommand;
using MashinAl.Business.Modules.ModelModule.Commands.ModelEditCommand;
using MashinAl.Business.Modules.ModelModule.Queries.ModelGetAllQuery;
using MashinAl.Business.Modules.ModelModule.Queries.ModelGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MashinAl.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ModelController : Controller
    {
        private readonly IMediator mediator;

        public ModelController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize("admin.model.index")]
        public async Task<IActionResult> Index(ModelGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [Authorize("admin.model.details")]
        public async Task<IActionResult> Details(ModelGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [Authorize("admin.model.create")]
        public async Task<IActionResult> Create()
        {
            ViewBag.MarkaId = new SelectList(await mediator.Send(new MarkaGetAllRequest()), "Id", "Name");
            return View();
        }

        [HttpPost]
        [Authorize("admin.model.create")]
        public async Task<IActionResult> Create(ModelAddRequest request)
        {
            await mediator.Send(request);

            return Json(new
            {
                success = true,
                message = "Model uğurla əlavə edildi!"
            });
        }

        [HttpPost]
        [Authorize("admin.model.delete")]
        public async Task<IActionResult> Delete(ModelRemoveRequest request, ModelGetAllRequest response)
        {
            await mediator.Send(request);

            var models = await mediator.Send(response);

            return PartialView("_Body", models);
        }

        [Authorize("admin.model.edit")]
        public async Task<IActionResult> Edit(ModelGetByIdRequest request)
        {

            ViewBag.MarkaId = new SelectList(await mediator.Send(new MarkaGetAllRequest()), "Id", "Name");

            var response = await mediator.Send(request);

            return View(response);
        }

        [HttpPost]
        [Authorize("admin.model.edit")]
        public async Task<IActionResult> Edit(ModelEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

    }
}
