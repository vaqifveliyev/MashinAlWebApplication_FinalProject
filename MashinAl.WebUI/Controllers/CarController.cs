using MashinAl.Business.Modules.CarModule.Commands.FavoriteAddCommand;
using MashinAl.Business.Modules.CarModule.Commands.FavoriteRemoveCommand;
using MashinAl.Business.Modules.CarModule.Queries.CarGetByIdQuery;
using MashinAl.Business.Modules.PlateModule.Queries.PlateGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Controllers
{
    
    public class CarController : Controller
    {
        private readonly IMediator mediator;

        public CarController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("masinlar/elan/{id}")]
        public async Task<IActionResult> Details(CarGetByIdRequest request)
        {
            var data = await mediator.Send(request);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorite(FavoriteAddRequest request)
        {
            var response = await mediator.Send(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorite(FavoriteRemoveRequest request)
        {
            var response = await mediator.Send(request);
            return Json(response);
        }

        public IActionResult Favorites()
        {
            return View();
        }
    }
}
