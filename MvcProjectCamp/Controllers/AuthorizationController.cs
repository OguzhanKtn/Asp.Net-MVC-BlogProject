using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.Ajax.Utilities;
using MvcProjectCamp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    [Authorize(Roles = "A")]
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

        [HttpGet]
        public ActionResult AddAdmin() 
        { 
            return View();  
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin) 
        {
            AdminValidator adminValidator = new AdminValidator();
            ValidationResult results = adminValidator.Validate(admin);

            if (results.IsValid)
            {
                admin.AdminPassword = PasswordHash(admin.AdminPassword);
                adminManager.Add(admin);
                return RedirectToAction("Index");
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

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
           var admin = adminManager.GetByID(id);
            return View(admin);
        }
        
        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            AdminValidator adminValidator = new AdminValidator();
            ValidationResult results = adminValidator.Validate(admin);

            if (results.IsValid)
            {
                admin.AdminPassword = PasswordHash(admin.AdminPassword);
                adminManager.Update(admin);
                return RedirectToAction("Index");
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

        public String PasswordHash(string password)
        {
           var hashPassword = PasswordHasher.HashPassword(password);
            return hashPassword;
        }
    }
}