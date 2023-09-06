using _02_DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Namari.Controllers
{
    public class GalleryController:Controller
    {
        private readonly IRepositoryManager _manager;

        public GalleryController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _manager.Gallery.Upload();
            return View();
        }

        //[HttpPost]
        //public IActionResult Index(IFormFile file)
        //{
        //    //_manager.Gallery.Upload(file);
        //    return View();
        //}
    }
}
