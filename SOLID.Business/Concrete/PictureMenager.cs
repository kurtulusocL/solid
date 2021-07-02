using SOLID.Business.Abstract;
using SOLID.DataAccess.Abstract;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOLID.Business.Concrete
{
    public class PictureMenager : IPictureService
    {
        private readonly IPictureDAL _pictureDAL;
        public PictureMenager(IPictureDAL pictureDAL)
        {
            _pictureDAL = pictureDAL;
        }
        public void Create(Picture model)
        {
            _pictureDAL.Add(model);
        }

        public void Delete(Picture model)
        {
            _pictureDAL.Delete(model);
        }

        public List<Picture> GetAllIncluding()
        {
            return _pictureDAL.GetAllIncluding().ToList();
        }

        public Picture GetById(int id)
        {
            return _pictureDAL.Get(i => i.Id == id);
        }

        public List<Picture> GetProduct(int? id)
        {
            return _pictureDAL.GetProduct(id).ToList();
        }

        public void Update(Picture model)
        {
            model.UpdatedDate = DateTime.Now.ToLocalTime();
            _pictureDAL.Update(model);
        }
    }
}
