using MashinAl.Business.Modules.BanTypeModule.Queries.BanTypeGetAllQuery;
using MashinAl.Business.Modules.CarModule.Commands.CarAddCommand;
using MashinAl.Business.Modules.CarModule.Commands.CarBoostCommand;
using MashinAl.Business.Modules.CarModule.Commands.CarRemoveCommand;
using MashinAl.Business.Modules.CarModule.Queries.CarGetAllQuery;
using MashinAl.Business.Modules.CarStatusModule.Queries.CarStatusGetAllQuery;
using MashinAl.Business.Modules.CityModule.Queries.CityGetAllQuery;
using MashinAl.Business.Modules.ColorModule.Queries.ColorGetAllQuery;
using MashinAl.Business.Modules.FuelTypeModule.Queries.FuelTypeGetAllQuery;
using MashinAl.Business.Modules.GearboxTypeModule.Queries.GearboxTypeGetAllQuery;
using MashinAl.Business.Modules.MarkasModule.Queries.MarkaGetAllQuery;
using MashinAl.Business.Modules.ModelModule.Queries.ModelGetAllQuery;
using MashinAl.Business.Modules.ModelModule.Queries.ModelGetByMarkaIdQuery;
using MashinAl.Business.Modules.RegionModule.Queries.RegionGetAllQuery;
using MashinAl.Business.Modules.SeatsModule.Queries.SeatsGetAllQuery;
using MashinAl.Business.Modules.SupplyModule.Queries.SupplyGetAllQuery;
using MashinAl.Business.Modules.TransmissionTypeModule.Queries.TransmissionTypeGetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MashinAl.WebUI.Areas.Dealership.Controllers
{
    [Area("Dealership")]
    public class CarController : Controller
    {
        private readonly IMediator mediator;

        public CarController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize("dealership.car.index")]
        public async Task<IActionResult> Index(CarGetAllRequest request)
        {
            var data = await mediator.Send(request);
            return View(data);
        }

        [Authorize("dealership.car.create")]
        public async Task<IActionResult> Create()
        {
            ViewBag.MarkaId = new SelectList(await mediator.Send(new MarkaGetAllRequest()), "Id", "Name");
            ViewBag.ModelId = new SelectList(await mediator.Send(new ModelGetAllRequest()), "Id", "Name");
            ViewBag.ColorId = new SelectList(await mediator.Send(new ColorGetAllRequest()), "Id", "Name");
            ViewBag.BanTypeId = new SelectList(await mediator.Send(new BanTypeGetAllRequest()), "Id", "Name");
            ViewBag.FuelTypeId = new SelectList(await mediator.Send(new FuelTypeGetAllRequest()), "Id", "Name");
            ViewBag.GearBoxTypeId = new SelectList(await mediator.Send(new GearboxTypeGetAllRequest()), "Id", "Name");
            ViewBag.SeatsId = new SelectList(await mediator.Send(new SeatsGetAllRequest()), "Id", "SeatTitle");
            ViewBag.TransmissionTypeId = new SelectList(await mediator.Send(new TransmissionTypeGetAllRequest()), "Id", "Name");
            ViewBag.CityId = new SelectList(await mediator.Send(new CityGetAllRequest()), "Id", "Name");
            ViewBag.CarStatusId = new SelectList(await mediator.Send(new CarStatusGetAllRequest()), "Id", "Title");
            ViewBag.RegionId = new SelectList(await mediator.Send(new RegionGetAllRequest()), "Id", "Title");
            ViewBag.SupplyId = new SelectList(await mediator.Send(new SupplyGetAllRequest()), "Id", "Title");

            return View();
        }

        [HttpPost]
        [Authorize("dealership.car.create")]
        public async Task<IActionResult> Create(CarAddDealerRequest request)
        {
            await mediator.Send(request);

            return Json(new
            {
                success = true,
                message = "Avtomobil elanı uğurla yoxlanışa göndərildi!"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetModelsByMarka(ModelGetByMarkaIdRequest request)
        {
            var data = await mediator.Send(request);
            return Json(data);

        }

        [HttpPost]
        [Authorize("dealership.cars.delete")]
        public async Task<IActionResult> Delete(CarRemoveRequest request)
        {
            await mediator.Send(request);

            return Json(new
            {
                error = false,
                message = "Qeyd silindi!"
            });
        }

        [HttpPost]
        [Authorize("dealership.cars.boostcar")]
        public async Task<IActionResult> BoostCar(CarBoostRequest request)
        {
            await mediator.Send(request);

            return Json(new {
                success = true,
                message = "Qeyd ireli cekildi!"
            });
        }
    }
}
