using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetAll();
        List<Heading> GetListByWriter(int id);
        void Add(Heading heading);
        Heading GetByID(int id);
        void Delete(Heading heading);
        void Update(Heading heading);
    }
}
