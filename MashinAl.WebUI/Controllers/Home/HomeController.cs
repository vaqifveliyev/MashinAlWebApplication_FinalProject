using MashinAl.Business.Modules.CarModule.Queries.CarGetAllQuery;
using MashinAl.Business.Modules.CarModule.Queries.ComplexSearchQuery;
using MashinAl.Business.Modules.DealerModule.Queries.DealetGetAllQuery;
using MashinAl.Business.Modules.ModelModule.Queries.ModelGetByMarkaIdQuery;
using MashinAl.Business.Modules.PlateModule.Queries.PlateComplexFilterQuery;
using MashinAl.Infastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Controllers.Home
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        //public async Task<IActionResult> Index(PlateGetAllRequest request)
        //{
        //    var response = await mediator.Send(request);

        //    return View(response);
        //}

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> All(CarGetAllRequest request)
        {
            var data = await mediator.Send(request);
            return View(data);
        }

        public async Task<IActionResult> Dealerships(DealerGetAllRequest request)
        {
            var data = await mediator.Send(request);
            return View(data);
        }

        public IActionResult Shops()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromForm] ComplexSearchRequest request)
        {
            var response = await mediator.Send(request);

            return View("Search", response);
        }

        [HttpGet]
        public async Task<IActionResult> GetModelsByMarka(ModelGetByMarkaIdRequest request)
        {
            var data = await mediator.Send(request);
            return Json(data);

        }

        [Route("/nomreler")]
        public async Task<IActionResult> Plates(PlateComplexFilterRequest request)
        {
            var data = await mediator.Send(request);


            if (Request.IsAjaxRequest())
                return PartialView("_Plates", data);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> PlateSearchAction(PlateComplexFilterRequest request)
        {
            var data = await mediator.Send(request);
            return PartialView("_Plates", data);
        }


        public async Task<IActionResult> Sort(string sortBy)
        {
            IEnumerable<CarGetAllDto> sortedData;

            var model = await mediator.Send(new CarGetAllRequest());

            switch (sortBy)
            {
                case "sort-by-date":
                    sortedData = model.OrderBy(c => c.PublishedAt); 
                    break;
                case "sort-lowprice-first":
                    sortedData = model.OrderBy(c => c.Price);
                    break;
                case "sort-highprice-first":
                    sortedData = model.OrderByDescending(c => c.Price); 
                    break;
                case "sort-year":
                    sortedData = model.OrderBy(c => c.YearId); 
                    break;
                default:
                    sortedData = model.OrderBy(c => c.PublishedAt); 
                    break;
            }

            return PartialView("_CarBody", sortedData);
        }







    }
}
