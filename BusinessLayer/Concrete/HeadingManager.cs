using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;
        private readonly Context _context;
        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
            _context = new Context();
        }

        public void Add(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void Delete(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public List<Heading> GetAll()
        {
           return _headingDal.List();
        }

        public Heading GetByID(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetHeadingsWithContents()
        {
            return _context.Headings.Include(x=>x.Contents).ToList();   
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterID == id);
        }

        public void Update(Heading heading)
        {
            var _heading = _headingDal.Get(x => x.HeadingID == heading.HeadingID);

            _heading.UpdatedDate = DateTime.Now;
            _heading.HeadingName = heading.HeadingName;
            _heading.HeadingStatus = heading.HeadingStatus;
            _heading.Category = heading.Category;
            _heading.CategoryID = heading.CategoryID;
            _heading.Contents = heading.Contents;
            _heading.Writer = heading.Writer;
            _heading.WriterID = heading.WriterID;

            _headingDal.Update(_heading);
        }
    }
}
