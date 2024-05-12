using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IImageService
    {
        List<ImageFile> GetAll();
        void Add(ImageFile imageFile);
        ImageFile GetByID(int id);
        void Delete(ImageFile imageFile);
        void Update(ImageFile imageFile);
    }
}
