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
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager;

        public WriterPanelContentController()
        {
            contentManager = new ContentManager(new EfContentDal());
        }

        public ActionResult MyContent()
        {
            List<Content> contents = contentManager.GetAllByWriter();
            return View(contents);
        }
    }
}