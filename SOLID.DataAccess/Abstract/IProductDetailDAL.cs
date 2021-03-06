using SOLID.Core.DataAccess;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.DataAccess.Abstract
{
    public interface IProductDetailDAL : IEntityRepository<ProductDetail>
    {
        List<ProductDetail> GetAllIncluding();
    }
}
