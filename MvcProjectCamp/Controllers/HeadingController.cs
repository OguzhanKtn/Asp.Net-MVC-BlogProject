using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager manager;
        CategoryManager categoryManager;
        public HeadingController()
        {
            manager = new HeadingManager(new EfHeadingDal());
            categoryManager = new CategoryManager(new EfCategoryDal());
        }

        public ActionResult Index()
        {
            var headings = manager.GetAll();
            return View(headings);
        }

        [HttpGet]
        public ActionResult AddHeading() 
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                                                  ).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p) 
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            manager.Add(p);
            return RedirectToAction("Index");
        }
    }
}