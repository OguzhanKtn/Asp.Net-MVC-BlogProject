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
    [AllowAnonymous]
    public class HomeController : Controller
    {
        HeadingManager headingManager;
        WriterManager writerManager;
        ContentManager contentManager;
        public HomeController()
        {
            headingManager = new HeadingManager(new EfHeadingDal());
            writerManager = new WriterManager(new EfWriterDal());
            contentManager = new ContentManager(new EfContentDal());
        }

        public ActionResult HomePage()
        {
            TitleWriterContentViewModel model = new TitleWriterContentViewModel();           
            model.headings = headingManager.GetAll();
            model.contents = contentManager.GetAll();
            model.writers = writerManager.GetList();
            return View(model);
        }
    }
}