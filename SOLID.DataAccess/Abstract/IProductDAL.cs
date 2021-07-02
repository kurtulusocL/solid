using SOLID.Core.DataAccess;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.DataAccess.Abstract
{
    public interface IProductDAL : IEntityRepository<Product>
    {
        List<Product> GetAllIncluding();
        Product HitRead(int? id);
        ProductDetail GetProductDetail(int? id);
        List<Product> Category(int? id);
    }
}
