using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAllIncluding();
        List<Product> Category(int? id);
        Product GetById(int id);
        ProductDetail GetProductDetail(int? id);
        Product HitRead(int? id);
        void Create(Product model);
        void Update(Product model);
        void Delete(Product model);
    }
}
