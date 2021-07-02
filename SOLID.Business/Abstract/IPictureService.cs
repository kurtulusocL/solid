using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Business.Abstract
{
    public interface IPictureService
    {
        List<Picture> GetAllIncluding();
        List<Picture> GetProduct(int? id);
        Picture GetById(int id);
        void Create(Picture model);
        void Update(Picture model);
        void Delete(Picture model);
    }
}
