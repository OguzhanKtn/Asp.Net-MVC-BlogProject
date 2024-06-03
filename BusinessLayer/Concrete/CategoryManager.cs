using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal;

        private readonly Context _context;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
            _context = new Context();
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.List();
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get(x => x.CategoryID == id);
        }

        public List<Category> GetCategoriesWithHeadings()
        {
            return _context.Categories.Include(x => x.Headings).ToList();
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
