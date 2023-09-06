using _01_EntityLayer;
using _02_DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Namari.Controllers
{
    public class ServicesController:Controller
    {
        private readonly IRepositoryManager _manager;

        public ServicesController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([FromForm] Services services)
        {
            _manager.Services.Add(services);
            _manager.Services.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult GetServicesList()
        {
            var model = _manager.Services.GetAll();
            return View(model);
        }

        public IActionResult Delete([FromRoute] int id)
        {
            var model = _manager.Services.GetById(id);
            _manager.Services.Remove(model);
            _manager.Services.SaveChanges();
            return RedirectToAction(nameof(GetServicesList));
        }

        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            var model = _manager.Services.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] Services services, [FromRoute] int id)
        {
            var model = _manager.Services.GetById(id);
            model.Title = services.Title;
            model.Description = services.Description;
            model.VideoUrl = services.VideoUrl;
            _manager.Services.SaveChanges();
            return RedirectToAction(nameof(GetServicesList));
        }
    }
}
