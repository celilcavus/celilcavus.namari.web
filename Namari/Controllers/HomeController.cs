using Microsoft.AspNetCore.Mvc;

namespace Namari.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
