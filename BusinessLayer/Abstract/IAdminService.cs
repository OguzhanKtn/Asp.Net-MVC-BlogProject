using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetAll();
        void Add(Admin admin);
        Admin GetByID(int id);
        void Delete(Admin admin);
        void Update(Admin admin);
    }
}
