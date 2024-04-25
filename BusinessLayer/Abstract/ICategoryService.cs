using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        void CategoryAdd(Category category);
        Category GetByID(int id);
        void Delete(Category category);
        void Update(Category category);
    }
}
