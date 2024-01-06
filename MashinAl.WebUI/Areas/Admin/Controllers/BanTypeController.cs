using MashinAl.Business.Modules.BanTypeModule.Commands.BanTypeAddCommand;
using MashinAl.Business.Modules.BanTypeModule.Commands.BanTypeEditCommand;
using MashinAl.Business.Modules.BanTypeModule.Commands.BanTypeRemoveCommand;
using MashinAl.Business.Modules.BanTypeModule.Queries.BanTypeGetAllQuery;
using MashinAl.Business.Modules.BanTypeModule.Queries.BanTypeGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BanTypeController : Controller
    {
        private readonly IMediator mediator;

        
        public BanTypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize("admin.bantype.index")]
        public async Task<IActionResult> Index(BanTypeGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [Authorize("admin.bantype.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize("admin.bantype.create")]
        public async Task<IActionResult> Create(BanTypeAddRequest request)
        {
            await mediator.Send(request);

            return Json(new
            {
                success = true,
                message = "Ban növü uğurla əlavə edildi!"
            });
        }

        [Authorize("admin.bantype.edit")]
        public async Task<IActionResult> Edit(BanTypeGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        [Authorize("admin.bantype.edit")]
        public async Task<IActionResult> Edit(BanTypeEditRequest request)
        {
            var response = await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [Authorize("admin.bantype.details")]
        public async Task<IActionResult> Details(BanTypeGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);

        }

        [HttpPost]
        [Authorize("admin.bantype.delete")]
        public async Task<IActionResult> Delete(BanTypeRemoveRequest request, BanTypeGetAllRequest response)
        {
            await mediator.Send(request);

            var bantypes = await mediator.Send(response);

            return PartialView("_Body", bantypes);
        }
    }
}
