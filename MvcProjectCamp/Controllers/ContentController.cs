using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager;

        public ContentController()
        {
            contentManager = new ContentManager(new EfContentDal());
        }

        public ActionResult GetAllContent(string p) 
        {
            var values = contentManager.GetBySearch(p);
            
            return View(values);
        }

        public ActionResult ContentByHeading(int id) 
        {
          List<Content> contents = contentManager.GetListByHeadingID(id);
            return View(contents);
        }
    }
}