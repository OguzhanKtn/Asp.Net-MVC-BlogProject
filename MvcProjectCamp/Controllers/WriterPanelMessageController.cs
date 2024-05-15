using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager;
        MessageValidator messageValidator;
        public WriterPanelMessageController()
        {
            messageManager = new MessageManager(new EfMessageDal());
            messageValidator = new MessageValidator();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}