using MashinAl.Business.Modules.CarModule.Queries.CarGetByIdQuery;
using MashinAl.Business.Modules.PlateModule.Queries.PlateGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Controllers
{
    [AllowAnonymous]
    public class CarController : Controller
    {
        private readonly IMediator mediator;

        public CarController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("masinlar/elan/{id}")]
        public async Task<IActionResult> Details(CarGetByIdRequest request)
        {
            var data = await mediator.Send(request);
            return View(data);
        }
    }
}
