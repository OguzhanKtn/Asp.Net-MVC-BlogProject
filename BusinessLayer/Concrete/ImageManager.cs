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
    public class ImageManager : IImageService
    {
        IImageFileDal _imageFileDal;
        public ImageManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }

        public void Add(ImageFile imageFile)
        {
            _imageFileDal.Insert(imageFile);
        }

        public void Delete(ImageFile imageFile)
        {
            _imageFileDal.Delete(imageFile);
        }

        public List<ImageFile> GetAll()
        {
            return _imageFileDal.List();
        }

        public ImageFile GetByID(int id)
        {
            return _imageFileDal.Get(x=>x.ImageID == id);
        }

        public void Update(ImageFile imageFile)
        {
            _imageFileDal.Update(imageFile);
        }
    }
}
