using Microsoft.AspNetCore.Mvc;

namespace Namari.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
        public IActionResult AdminPanel()
        {
            return View();
        }
    }
}
