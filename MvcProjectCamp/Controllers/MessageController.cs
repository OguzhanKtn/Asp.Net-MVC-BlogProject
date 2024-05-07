using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager;
        public MessageController() 
        { 
            messageManager = new MessageManager(new EfMessageDal());
        }
        public ActionResult Inbox()
        {
            var messages = messageManager.GetAll();
            return View(messages);
        }
    }
}