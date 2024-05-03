using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;
        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void Add(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void Delete(Heading heading)
        {
            _headingDal.Delete(heading);
        }

        public List<Heading> GetAll()
        {
           return _headingDal.List();
        }

        public Heading GetByID(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id);
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
