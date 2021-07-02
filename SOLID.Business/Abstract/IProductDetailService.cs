using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Business.Abstract
{
    public interface IProductDetailService
    {
        List<ProductDetail> GetAllIncluding();
        ProductDetail GetById(int id);
        void Create(ProductDetail model);
        void Update(ProductDetail model);
        void Delete(ProductDetail model);
    }
}
