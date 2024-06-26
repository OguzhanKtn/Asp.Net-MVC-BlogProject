﻿using BusinessLayer.Concrete;
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
        WriterLoginManager writerLoginManager;
        public LoginController()
        {
            adminManager = new AdminManager(new EfAdminDal());
            writerLoginManager = new WriterLoginManager(new EfWriterDal());
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var hashPassword = PasswordHasher.HashPassword(p.AdminPassword);
            List<Admin> admins = adminManager.GetAll();

            var adminUser = admins.FirstOrDefault(x => x.AdminUserName.Equals(p.AdminUserName) && x.AdminPassword.Equals(hashPassword));

            if (adminUser != null) 
            {
                FormsAuthentication.SetAuthCookie(adminUser.AdminUserName,false);
                Session["AdminUserName"] = adminUser.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("AdminLogin");
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
            var hashPassword = PasswordHasher.HashPassword(p.WriterPassword);

            var writerUser = writerLoginManager.GetWriter(p.WriterMail,hashPassword);

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

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}