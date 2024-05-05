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
    public class AboutController : Controller
    {
        AboutManager aboutManager;
        public AboutController()
        {
            aboutManager = new AboutManager(new EfAboutDal());
        }

        public ActionResult Index()
        {
            var aboutValues = aboutManager.GetAll();
            return View(aboutValues);
        }

        [HttpGet]
        public ActionResult AddAbout() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            aboutManager.Add(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}