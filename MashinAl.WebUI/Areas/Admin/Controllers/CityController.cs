using MashinAl.Business.Modules.CityModule.Commands.CityAddCommand;
using MashinAl.Business.Modules.CityModule.Commands.CityEditCommand;
using MashinAl.Business.Modules.CityModule.Commands.CityRemoveCommand;
using MashinAl.Business.Modules.CityModule.Queries.CityGetAllQuery;
using MashinAl.Business.Modules.CityModule.Queries.CityGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IMediator mediator;

        
        public CityController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize("admin.city.index")]
        public async Task<IActionResult> Index(CityGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [Authorize("admin.city.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize("admin.city.create")]
        public async Task<IActionResult> Create(CityAddRequest request)
        {
            await mediator.Send(request);

            return Json(new
            {
                success = true,
                message = "Şəhər & rayon uğurla əlavə edildi!"
            });
        }

        [Authorize("admin.city.edit")]
        public async Task<IActionResult> Edit(CityGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        [Authorize("admin.city.edit")]
        public async Task<IActionResult> Edit(CityEditRequest request)
        {
            var response = await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [Authorize("admin.city.details")]
        public async Task<IActionResult> Details(CityGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);

        }

        [HttpPost]
        [Authorize("admin.city.delete")]
        public async Task<IActionResult> Delete(CityRemoveRequest request, CityGetAllRequest response)
        {
            await mediator.Send(request);

            var bantypes = await mediator.Send(response);

            return PartialView("_Body", bantypes);
        }
    }
}
