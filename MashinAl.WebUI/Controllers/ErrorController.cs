using Microsoft.AspNetCore.Mvc;

namespace MashinAl.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/404")]
        public IActionResult NotFoundError()
        {
            return View();
        }
    }
}
