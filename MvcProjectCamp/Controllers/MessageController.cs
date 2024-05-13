using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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

        public ActionResult ReadMessages()
        {
            var messages = messageManager.GetListInbox().Where(x => x.IsRead == true).ToList();
            return View(messages);
        }

        public ActionResult UnreadMessages()
        {
            var messages = messageManager.GetListInbox().Where(x => x.IsRead == false).ToList();
            return View(messages);  
        }

        public ActionResult Sendbox() 
        { 
            var messages = messageManager.GetListSendBox();
            return View(messages);
        }

        public ActionResult GetInboxDetails(int id)
        {
            var values = messageManager.GetByID(id);
            values.IsRead = true;
            messageManager.Update(values);
            return View(values);
        }

        public ActionResult GetSendboxDetails(int id)
        {
            var values = messageManager.GetByID(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p) 
        {
            MessageValidator messageValidator = new MessageValidator();
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.Add(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}