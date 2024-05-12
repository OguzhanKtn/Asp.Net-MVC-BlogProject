using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjectCamp.Controllers
{
    public class LoginController : Controller
    {
        AdminManager adminManager;
        public LoginController()
        {
            adminManager = new AdminManager(new EfAdminDal());
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            List<Admin> admins = adminManager.GetAll();

            var adminUser = admins.FirstOrDefault(x => x.AdminUserName.Equals(p.AdminUserName) && x.AdminPassword.Equals(p.AdminPassword));

            if (adminUser != null) 
            {
                FormsAuthentication.SetAuthCookie(adminUser.AdminUserName,false);
                Session["AdminUserName"] = adminUser.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}