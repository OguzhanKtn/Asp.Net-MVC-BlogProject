using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager;
        HeadingManager headingManager;
        public AdminCategoryController()
        {
            categoryManager = new CategoryManager(new EfCategoryDal());
            headingManager = new HeadingManager(new EfHeadingDal());
        }

        public ActionResult Index()
        {
            var categories = categoryManager.GetAll();
            return View(categories);
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
                categoryManager.CategoryAdd(p);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var category = categoryManager.GetByID(id);
            categoryManager.Delete(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var category = categoryManager.GetByID(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            categoryManager.Update(category);
            return RedirectToAction("Index");
        }

        public ActionResult Titles(int id)
        {
            List<Heading> headingList = new List<Heading>();
            foreach (var item in headingManager.GetAll())
            {
                if(item.CategoryID == id)
                {
                    headingList.Add(item);
                }
            }
            return View(headingList);
        }
    }
}