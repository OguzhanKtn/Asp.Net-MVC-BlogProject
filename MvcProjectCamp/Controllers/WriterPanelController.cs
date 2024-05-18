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

        public ActionResult MyHeading(string p)
        {
            p = (string)Session["WriterMail"];
            var writerIdInfo = headingManager.GetAll().Where(x => x.Writer.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values = headingManager.GetListByWriter(writerIdInfo);
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
            string writerMail = (string)Session["WriterMail"];
            var writerIdInfo = headingManager.GetAll().Where(x => x.Writer.WriterMail == writerMail).Select(y => y.WriterID).FirstOrDefault();
            p.CreatedDate = DateTime.Now;
            p.WriterID = writerIdInfo;
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

        public ActionResult AllHeading()
        {
            var headings = headingManager.GetAll();
            return View(headings);
        }
    }
}