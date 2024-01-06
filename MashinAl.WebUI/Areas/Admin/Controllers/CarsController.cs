using MashinAl.Business.Modules.CarModule.Commands.CarPublishCommand;
using MashinAl.Business.Modules.CarModule.Commands.CarRejectCommand;
using MashinAl.Business.Modules.CarModule.Commands.CarRemoveCommand;
using MashinAl.Business.Modules.CarModule.Queries.CarGetAllQuery;
using MashinAl.Business.Modules.CarModule.Queries.CarGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarsController : Controller
    {
        private readonly IMediator mediator;

        public CarsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [Authorize("admin.cars.index")]
        public async Task<IActionResult> Index(CarGetAllRequest request)
        {
            var data = await mediator.Send(request);
            return View(data);
        }

        [Authorize("admin.cars.details")]
        public async Task<IActionResult> Details(CarGetByIdRequest request)
        {
            var data = await mediator.Send(request);
            return View(data);
        }

        [HttpPost]
        [Authorize("admin.cars.publish")]
        public async Task<IActionResult> Publish(CarPublishRequest request)
        {
            await mediator.Send(request);

            return Json(new
            {
                success = true,
                message = "Avtomobil elanı təsdiqləndi!"
            });
        }

        [HttpPost]
        [Authorize("admin.cars.delete")]
        public async Task<IActionResult> Delete(CarRemoveRequest request, CarGetAllRequest response)
        {
            await mediator.Send(request);
            var data = await mediator.Send(response);
            return PartialView("_Body", data);
        }

        [HttpPost]
        [Authorize("admin.cars.reject")]
        public async Task<IActionResult> Reject(CarRejectRequest request)
        {
            await mediator.Send(request);

            return Json(new
            {
                success = true,
                message = "Avtomobil elanı imtina edildi!"
            });
        }


    }
}
