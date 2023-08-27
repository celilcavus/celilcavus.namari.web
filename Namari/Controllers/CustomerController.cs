using _01_EntityLayer;
using _02_DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Namari.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepositoryManager _manager;

        public CustomerController(IRepositoryManager manager)
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
        public IActionResult Index(Customers customers)
        {
            _manager.Customer.Add(customers);
            _manager.Customer.SaveChanges();
            return View();
        }


    }
}
