using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;
using MvcProjectCamp.Core;

namespace MvcProjectCamp.Controllers
{
    [Authorize(Roles = "A")]
    public class WriterController : Controller
    {
        WriterManager writerManager;
        public WriterController()
        {
            writerManager = new WriterManager(new EfWriterDal());
        }

        public ActionResult Index()
        {
            var writers = writerManager.GetList();
            return View(writers);
        }

        [HttpGet]
        public ActionResult AddWriter() 
        {
            return View();        
        }

        [HttpPost]
        public ActionResult AddWriter(Writer p) 
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(p);
           
            if(results.IsValid) 
            {
                var hashPassword = PasswordHasher.HashPassword(p.WriterPassword);
                p.WriterPassword = hashPassword;
                writerManager.WriterAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult UpdateWriter(int id) 
        {
            var writer = writerManager.GetByID(id);
            return View(writer);
        }

        [HttpPost]
        public ActionResult UpdateWriter(Writer writer) 
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                var hashPassword = PasswordHasher.HashPassword(writer.WriterPassword);
                writer.WriterPassword = hashPassword;
                writerManager.WriterUpdate(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}