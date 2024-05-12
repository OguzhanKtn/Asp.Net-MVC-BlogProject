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
    public class GalleryController : Controller
    {
        ImageManager imageManager;
        public GalleryController()
        {
            imageManager = new ImageManager(new EfImageDal());
        }

        public ActionResult Index()
        {
           List<ImageFile> images = imageManager.GetAll();
            return View(images);
        }
    }
}