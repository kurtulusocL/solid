using SOLID.Core.DataAccess;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.DataAccess.Abstract
{
    public interface IPictureDAL: IEntityRepository<Picture>
    {
        List<Picture> GetAllIncluding();
        List<Picture> GetProduct(int? id);
    }
}
