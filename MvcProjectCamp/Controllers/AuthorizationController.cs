using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adminManager;
        public AuthorizationController()
        {
            adminManager = new AdminManager(new EfAdminDal());
        }

        public ActionResult Index()
        {
            var admins = adminManager.GetAll(); 
            return View(admins);
        }
    }
}