using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using MvcProjectCamp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminManager adminManager;
        WriterManager writerManager;
        public LoginController()
        {
            adminManager = new AdminManager(new EfAdminDal());
            writerManager = new WriterManager(new EfWriterDal());
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
        [HttpGet]
        public ActionResult WriterLogin() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            List<Writer> writers = writerManager.GetList();
            var hashPassword = PasswordHasher.HashPassword(p.WriterPassword);
           
            var writerUser = writers.FirstOrDefault(x => x.WriterMail.Equals(p.WriterMail) && x.WriterPassword.Equals(hashPassword));

            if ( writerUser != null)
            {
                FormsAuthentication.SetAuthCookie(writerUser.WriterMail, false);
                Session["WriterMail"] = writerUser.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
            return View();
        }
    }
}