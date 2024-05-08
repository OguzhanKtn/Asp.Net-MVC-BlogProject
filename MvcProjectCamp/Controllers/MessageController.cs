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
    public class MessageController : Controller
    {
        MessageManager messageManager;
        public MessageController() 
        { 
            messageManager = new MessageManager(new EfMessageDal());
        }
        public ActionResult Inbox()
        {
            var messages = messageManager.GetListInbox();
            return View(messages);
        }

        public ActionResult Sendbox() 
        { 
            var messages = messageManager.GetListSendBox();
            return View(messages);
        }

        [HttpGet]
        public ActionResult NewMessage() 
        { 
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message) 
        {
            return View();
        }
    }
}