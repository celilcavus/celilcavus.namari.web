using _01_EntityLayer;
using _02_DataAccess;
using _02_DataAccess.Interfaces;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Namari.FluentValidation;

namespace Namari.Controllers
{
    public class ClientsController : Controller
    {

        private IRepositoryManager _repository;

        private readonly ClientsValidatior valid = new();
        private ValidationResult? validationResult;

        public ClientsController(IRepositoryManager repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([FromForm] Clients clients)
        {
            validationResult = valid.Validate(clients);

            if (validationResult.IsValid)
            {
                _repository.Clients.Add(clients);
                _repository.Clients.SaveChanges();
                return View();
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError("", item.ErrorMessage);
                }
                return View();
            }
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var model = _repository.Clients.GetAll();
            return View(model);
        }

        public IActionResult Delete([FromRoute] int id)
        {
            int? _id = id;
            if (_id.HasValue)
            {
                var value = _repository.Clients.GetById(_id.Value);
                if (value != null)
                {
                    _repository.Clients.Remove(value);
                    _repository.Clients.SaveChanges();

                    return RedirectToAction(nameof(GetList));
                }
                else
                    return NotFound();
            }
            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            int? _id = id;
            if (_id.HasValue)
            {
                var value = _repository.Clients.GetById(_id.Value);
                if (value != null)
                {
                    return View(value);
                }
                else
                    return NotFound();
            }
            else
                return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] Clients clients, [FromRoute] int id)
        {
            validationResult = valid.Validate(clients);
            if (validationResult.IsValid)
            {
                var cli = _repository.Clients.GetById(id);
                cli.Title = clients.Title;
                _repository.Clients.SaveChanges();

                return RedirectToAction(nameof(GetList));
            }
            else
                return RedirectToAction(nameof(Update));
        }

    }
}
