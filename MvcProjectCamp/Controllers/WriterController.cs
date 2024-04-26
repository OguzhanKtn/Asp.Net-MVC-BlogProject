using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager;
        public WriterController()
        {
            writerManager = new WriterManager(new EfWriterDal());
        }

        public ActionResult Index()
        {
            var writers = writerManager.GetList();
            return View(writers);
        }
    }
}