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
        List<Content> GetBySearch(string p);
        List<Content> GetAllByWriter(int id);
        List<Content> GetListByHeadingID(int id);
        void Add(Content content);
        Content GetByID(int id);
        void Delete(Content content);
        void Update(Content content);
    }
}
