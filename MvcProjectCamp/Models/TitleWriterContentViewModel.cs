using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjectCamp.Models
{
    public class TitleWriterContentViewModel
    {
        public List<Heading> headings {  get; set; }
        public List<Writer> writers { get; set; }
        public List<Content> contents { get; set; }
    }
}