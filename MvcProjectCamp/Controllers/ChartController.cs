using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using MvcProjectCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    [Authorize(Roles = "A")]
    public class ChartController : Controller
    {
        CategoryManager categoryManager;
        public ChartController() 
        { 
         categoryManager = new CategoryManager(new EfCategoryDal());
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart() 
        { 
            return Json(BlogList(),JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> categoryClasses = new List<CategoryClass>();
            List<Category> categories = categoryManager.GetCategoriesWithHeadings();
            foreach (Category category in categories) 
            {
                categoryClasses.Add(new CategoryClass()
                {
                    CategoryName = category.CategoryName,
                    CategoryCount = category.Headings.Count,
                });
                
            }
          
            return categoryClasses;
        }
    }
}