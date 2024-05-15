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
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager;
        CategoryManager categoryManager;
        public WriterPanelController()
        {
            headingManager = new HeadingManager(new EfHeadingDal());
            categoryManager = new CategoryManager(new EfCategoryDal());
        }

        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading(int id)
        {
            var values = headingManager.GetListByWriter(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading() 
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                                                  ).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            p.CreatedDate = DateTime.Now;
           
            headingManager.Add(p);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                                                  ).ToList();
            ViewBag.vlc = valueCategory;
            var HeadingValue = headingManager.GetByID(id);
            return View(HeadingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            headingManager.Update(p);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var heading = headingManager.GetByID(id);
            heading.HeadingStatus = false;
            headingManager.Delete(heading);

            return RedirectToAction("MyHeading");
        }
    }
}