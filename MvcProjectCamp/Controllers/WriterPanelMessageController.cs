using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ActionResult ReadMessages()
        {
            string p = (string)Session["WriterMail"];
            var messages = messageManager.GetListInbox(p).Where(x => x.IsRead == true && x.IsDeleted == false).ToList();
            return View(messages);
        }

        public ActionResult UnreadMessages()
        {
            string p = (string)Session["WriterMail"];
            var messages = messageManager.GetListInbox(p).Where(x => x.IsRead == false).ToList();
            return View(messages);
        }

        public ActionResult DeletedMessages()
        {
            string p = (string)Session["WriterMail"];
            var messages = messageManager.GetListInbox(p).Where(x => x.IsDeleted == true).ToList();
            return View(messages);
        }

        /* public async Task<ActionResult> DeleteMessage(string messageIds)
         {
             try
             {
                 string p = (string)Session["WriterMail"];
                 string[] Ids = messageIds.Split(',');
                 List<Message> messages = messageManager.GetListInbox(p);

                 if (!string.IsNullOrEmpty(messageIds) && Ids.Length > 0)
                 {
                     foreach (var item in messages)
                     {
                         foreach (var id in Ids)
                         {
                             if (item.MessageID == Convert.ToInt32(id))
                             {
                                 item.IsDeleted = true;
                                 await messageManager.Update(item);
                             }
                         }
                     }
                 }

                 System.Diagnostics.Debug.WriteLine("Yönlendirme yapılacak: ReadMessages");

                 return RedirectToAction("ReadMessages", "WriterPanelMessage");
             }
             catch (Exception ex)
             {
                 System.Diagnostics.Debug.WriteLine("Hata oluştu: " + ex.Message);
                 return View("Error");
             }
         }*/

        [HttpPost]
        public async Task<JsonResult> DeleteMessage(string messageIds)
        {
            try
            {
                string p = (string)Session["WriterMail"];
                string[] Ids = messageIds.Split(',');
                List<Message> messages = messageManager.GetListInbox(p);

                if (!string.IsNullOrEmpty(messageIds) && Ids.Length > 0)
                {
                    foreach (var item in messages)
                    {
                        foreach (var id in Ids)
                        {
                            if (item.MessageID == Convert.ToInt32(id))
                            {
                                item.IsDeleted = true;
                                await messageManager.Update(item);
                            }
                        }
                    }
                }

                System.Diagnostics.Debug.WriteLine("Yönlendirme yapılacak: ReadMessages");
                return Json(new { result = "Ok" });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Hata oluştu: " + ex.Message);
                return Json(new { result = "Fail" });
            }
        }


        [HttpPost]
        public async Task<JsonResult> RetrieveMessage(string messageIds)
        {
            try
            {
                string p = (string)Session["WriterMail"];
                string[] Ids = messageIds.Split(',');
                List<Message> messages = messageManager.GetListInbox(p);

                if (!string.IsNullOrEmpty(messageIds) && Ids.Length > 0)
                {
                    foreach (var item in messages)
                    {
                        foreach (var id in Ids)
                        {
                            if (item.MessageID == Convert.ToInt32(id))
                            {
                                item.IsDeleted = false;
                                await messageManager.Update(item);
                            }
                        }
                    }
                }

                System.Diagnostics.Debug.WriteLine("Yönlendirme yapılacak: DeletedMessages");
                return Json(new { result = "Ok" });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Hata oluştu: " + ex.Message);
                return Json(new { result = "Fail" });
            }
        }

        public ActionResult GetInboxDetails(int id)
        {
            var values = messageManager.GetByID(id);
            values.IsRead = true;
            messageManager.Update(values);
            return View(values);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messages = messageManager.GetListSendBox(p);
            return View(messages);
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
                string writerInfo = (string)Session["WriterMail"];
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.SenderMail = writerInfo;
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
        public PartialViewResult MessageListMenu()
        {
            string p = (string)Session["WriterMail"];
            var messages = messageManager.GetListInbox(p);
            return PartialView(messages);
        }
    }
}