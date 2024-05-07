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
    public class ContactController : Controller
    {
        ContactManager contactManager;
        ContactValidator contactValidator;
        public ContactController()
        {
            contactManager =  new ContactManager(new EfContactDal());
            contactValidator = new ContactValidator();
        }

        public ActionResult Index()
        {
            var contacts = contactManager.GetAll();
            return View(contacts);
        }

        public ActionResult GetContactDetails(int id) 
        {
            var contact = contactManager.GetByID(id);
            return View(contact);
        }

        public PartialViewResult ContactPartial()
        {
            return PartialView();
        }
    }
}