using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjectCamp.Models
{
    public class ContactMessageViewModel
    {
        public List<Contact> Contacts { get; set; }
        public List<Message> Messages { get; set; }
    }
}