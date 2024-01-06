using MashinAl.Business.Modules.CarModule.Queries.CarGetAllQuery;
using MashinAl.Business.Modules.PlateModule.Queries.PlateGetAllQuery;
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

        public IActionResult All()
        {
            return View();
        }

        public IActionResult Dealerships()
        {
            return View();
        }

        public IActionResult Shops()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }


    }
}
