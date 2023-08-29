using _01_EntityLayer;
using _02_DataAccess.Interfaces;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Namari.FluentValidation;

namespace Namari.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepositoryManager _manager;
        private readonly CustomerValidatior customerValid = new();

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
            ValidationResult validationResult = customerValid.Validate(customers);

            if (validationResult.IsValid)
            {
                _manager.Customer.Add(customers);
                _manager.Customer.SaveChanges();
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError("", item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult GetCustomerList()
        {
            var modelVal = _manager.Customer.GetAll();
            return View(modelVal);
        }


        public IActionResult Delete([FromRoute] int id)
        {
            int? _id = id;
            if (_id.HasValue && _id.Value > 0)
            {
                Customers? value = _manager.Customer.GetById(_id.Value);
                if (value != null)
                {
                    _manager.Customer.Remove(value);
                    _manager.Customer.SaveChanges();
                }
                else
                    return NoContent();
            }
            return RedirectToAction(nameof(GetCustomerList));
        }

        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            int? _id = id;
            if (_id.HasValue && _id.Value > 0)
            {
                Customers? value = _manager.Customer.GetById(_id.Value);
                if (value != null)
                {
                    return View(value);
                }
                else
                    return NoContent();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] Customers custom, [FromRoute] int id)
        {
            int? _id = id;
            if (_id.HasValue && _id.Value > 0)
            {
                Customers? value = _manager.Customer.GetById(_id.Value);
                if (value != null)
                {
                    value.Image = custom.Image;
                    value.Description = custom.Description;
                    value.FirstName = custom.FirstName;
                    value.LastName = custom.LastName;
                    _manager.Customer.SaveChanges();
                }
                else
                    return NoContent();
            }
            return View();
        }
    }
}
