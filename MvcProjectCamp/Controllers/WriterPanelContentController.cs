using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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
        Context context;
        public WriterPanelContentController()
        {
            contentManager = new ContentManager(new EfContentDal());
            context = new Context();
        }

        public ActionResult MyContent(string p)
        {
            p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            
            List<Content> contents = contentManager.GetAllByWriter(writerIdInfo);
            return View(contents);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.Id = id;  
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p) 
        { 
            p.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            string writerInfo = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == writerInfo).Select(y => y.WriterID).FirstOrDefault();
            p.WriterID = writerIdInfo;

            contentManager.Add(p);
            return RedirectToAction("MyContent");
        }


    }
}