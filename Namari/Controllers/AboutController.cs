using _01_EntityLayer;
using _02_DataAccess;
using _02_DataAccess.Interfaces;
using _02_DataAccess.Repository;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Namari.FluentValidation;

namespace Namari.Controllers
{
    public class AboutController : Controller
    {

        private readonly IRepositoryManager repositoryManager;

        public AboutController(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        private readonly AboutValidatior validationRules = new();

       
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([FromForm] About about)
        {
            ValidationResult result = validationRules.Validate(about);
            if (result.IsValid)
            {
                repositoryManager.About.Add(about);
                repositoryManager.About.SaveChanges();

                return View();
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.ErrorMessage);
                }
                return View();
            }
        }
        [HttpGet]
        public IActionResult GetList()
        {
            var model = repositoryManager.About.GetAll();
            return View(model);
        }
        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            int? _id = id;
            if (_id.HasValue && id > 0)
            {
                About findModel = repositoryManager.About.GetById(_id.Value);
                return View(findModel);
            }
            else
                return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] About about, [FromRoute] int id)
        {
            ValidationResult valid = validationRules.Validate(about);
            if (valid.IsValid)
            {
                var model = repositoryManager.About.GetById(id);
                if (model != null)
                {
                    model.Title = about.Title;
                    model.Description = about.Description;
                    model.Icon = about.Icon;
                    model.IconTitle = about.IconTitle;
                    model.IconDescription = about.IconDescription;
                    repositoryManager.About.SaveChanges();
                }
                else
                    RedirectToAction(nameof(GetList));
                return RedirectToAction(nameof(GetList));
            }
            else
            {
                foreach (var item in valid.Errors)
                {
                    ModelState.AddModelError("", item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                int? _id = id;
                if (_id.HasValue && id > 0)
                {
                    About findModel = repositoryManager.About.GetById(_id.Value);
                    if (findModel != null)
                    {
                        repositoryManager.About.Remove(findModel);
                        repositoryManager.About.SaveChanges();
                        return RedirectToAction(nameof(GetList));
                    }
                    else
                        return NotFound();

                }
                else
                    return NotFound();
            }
            catch (SqliteException)
            {
                return RedirectToAction(nameof(GetList));
            }

        }
    }
}
