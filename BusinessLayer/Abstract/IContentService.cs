using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetAll();
        List<Content> GetListByID(int id);
        void Add(Content content);
        Content GetByID(int id);
        void Delete(Content content);
        void Update(Content content);
    }
}
