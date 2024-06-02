using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void Add(Content content)
        {
            content.UpdatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _contentDal.Insert(content);
        }

        public void Delete(Content content)
        {
            _contentDal.Delete(content);
        }

        public List<Content> GetAll()
        {
          return _contentDal.List();    
        }

        public List<Content> GetAllByWriter(int id)
        {
            return _contentDal.List(x => x.WriterID == id);
        }

        public Content GetByID(int id)
        {
            return _contentDal.Get(x=>x.ContentID == id);
        }

        public List<Content> GetBySearch(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return _contentDal.List(x=>x.ContentValue.Contains(p));
            }
            else
            {
                return _contentDal.List();
            }
        }

        public List<Content> GetListByHeadingID(int id)
        {
           return _contentDal.List(x=>x.HeadingID == id);
        }

        public void Update(Content content)
        {
            content.UpdatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _contentDal.Update(content);
        }

    }
}
