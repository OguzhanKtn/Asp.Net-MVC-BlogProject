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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(About about)
        {
            _aboutDal.Insert(about);
        }

        public void Delete(About about)
        {
            _aboutDal.Delete(about);  
        }

        public List<About> GetAll()
        {
            return _aboutDal.List();
        }

        public About GetByID(int id)
        {
            return _aboutDal.Get(x => x.AboutID == id);
        }

        public void Update(About about)
        {
            _aboutDal.Update(about);
        }
    }
}
