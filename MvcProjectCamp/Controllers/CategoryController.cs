using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager manager;

        public CategoryController()
        {
            manager = new CategoryManager(new EfCategoryDal());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryvalues = manager.GetAll();
            return View(categoryvalues);
        }
        [HttpGet]
        public ActionResult AddCategory() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(p);
            if (validationResult.IsValid)
            {
                manager.CategoryAdd(p);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach(var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}