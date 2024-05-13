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
        HeadingManager headingManager;
        CategoryManager categoryManager;
        WriterManager writerManager;
        public HeadingController()
        {
            headingManager = new HeadingManager(new EfHeadingDal());
            categoryManager = new CategoryManager(new EfCategoryDal());
            writerManager = new WriterManager(new EfWriterDal());
        }

        public ActionResult Index()
        {
            var headings = headingManager.GetAll();
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
            List<SelectListItem> valueCategory2 = (from x in writerManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.WriterName +" "+ x.WriterSurname,
                                                       Value = x.WriterID.ToString()
                                                   }
                                                   ).ToList();   
            ViewBag.vlc = valueCategory;
            ViewBag.writer = valueCategory2;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p) 
        {
            p.CreatedDate = DateTime.Now; 
            headingManager.Add(p);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        public ActionResult HeadingByWriter(int id)
        {
            var titles = headingManager.GetAll().Where(x => x.WriterID == id).ToList();
            return View(titles);
        }

        public ActionResult DeleteHeading(int id)
        {
            var heading = headingManager.GetByID(id);
            heading.HeadingStatus = false;
            headingManager.Delete(heading);

            return RedirectToAction("Index");
        }

        public ActionResult ActivateHeading(int id)
        {
            var heading = headingManager.GetByID(id);
            heading.HeadingStatus = true;
            headingManager.Update(heading);

            return RedirectToAction("Index");
        }
    }
}