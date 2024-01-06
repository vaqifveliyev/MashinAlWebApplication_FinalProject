using MashinAl.Business.Modules.BanTypeModule.Queries.BanTypeGetAllQuery;
using MashinAl.Business.Modules.CarModule.Commands.CarAddCommand;
using MashinAl.Business.Modules.CarStatusModule.Queries.CarStatusGetAllQuery;
using MashinAl.Business.Modules.CityModule.Queries.CityGetAllQuery;
using MashinAl.Business.Modules.ColorModule.Queries.ColorGetAllQuery;
using MashinAl.Business.Modules.FuelTypeModule.Queries.FuelTypeGetAllQuery;
using MashinAl.Business.Modules.GearboxTypeModule.Queries.GearboxTypeGetAllQuery;
using MashinAl.Business.Modules.MarkasModule.Queries.MarkaGetAllQuery;
using MashinAl.Business.Modules.ModelModule.Queries.ModelGetAllQuery;
using MashinAl.Business.Modules.PlateModule.Commands.PlateAddCommand;
using MashinAl.Business.Modules.RegionModule.Queries.RegionGetAllQuery;
using MashinAl.Business.Modules.SeatsModule.Queries.SeatsGetAllQuery;
using MashinAl.Business.Modules.SupplyModule.Queries.SupplyGetAllQuery;
using MashinAl.Business.Modules.TransmissionTypeModule.Queries.TransmissionTypeGetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MashinAl.WebUI.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IMediator mediator;

        public AnnouncementController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.MarkaId = new SelectList(await mediator.Send(new MarkaGetAllRequest()), "Id", "Name");
            ViewBag.ModelId = new SelectList(await mediator.Send(new ModelGetAllRequest()), "Id", "Name");
            ViewBag.ColorId = new SelectList(await mediator.Send(new ColorGetAllRequest()), "Id", "Name");
            ViewBag.BanTypeId = new SelectList(await mediator.Send(new BanTypeGetAllRequest()), "Id", "Name");
            ViewBag.FuelTypeId = new SelectList(await mediator.Send(new FuelTypeGetAllRequest()), "Id", "Name");
            ViewBag.GearBoxTypeId = new SelectList(await mediator.Send(new GearboxTypeGetAllRequest()), "Id", "Name");
            ViewBag.SeatsId = new SelectList(await mediator.Send(new SeatsGetAllRequest()), "Id", "SeatTitle");
            ViewBag.TransmissionTypeId = new SelectList(await mediator.Send(new TransmissionTypeGetAllRequest()), "Id", "Name");
            ViewBag.YearId = new SelectList(await mediator.Send(new TransmissionTypeGetAllRequest()), "Id", "YearTitle");
            ViewBag.CityId = new SelectList(await mediator.Send(new CityGetAllRequest()), "Id", "Name");
            ViewBag.CarStatusId = new SelectList(await mediator.Send(new CarStatusGetAllRequest()), "Id", "Title");
            ViewBag.RegionId = new SelectList(await mediator.Send(new RegionGetAllRequest()), "Id", "Title");
            ViewBag.SupplyId = new SelectList(await mediator.Send(new SupplyGetAllRequest()), "Id", "Title");

            return View();
        }

        public IActionResult CreateCar()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateCar([FromForm] CarAddRequest request)
        {
            var response = await mediator.Send(request);
            return Json(new
            {
                success = true,
                message = "Elan uğurla yoxlanışa göndərildi!"
            });
        }


        public IActionResult CreatePlate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlate([FromForm] PlateAddRequest request)
        {
            var response = await mediator.Send(request);
            return Json(new
            {
                success = true,
                message = "Elan uğurla yoxlanışa göndərildi!"
            });
        }

    }
}
