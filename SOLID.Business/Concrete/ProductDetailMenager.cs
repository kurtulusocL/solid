using SOLID.Business.Abstract;
using SOLID.DataAccess.Abstract;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOLID.Business.Concrete
{
    public class ProductDetailMenager : IProductDetailService
    {
        private readonly IProductDetailDAL _productDetailDAL;
        public ProductDetailMenager(IProductDetailDAL productDetailDAL)
        {
            _productDetailDAL = productDetailDAL;
        }
        public void Create(ProductDetail model)
        {
            _productDetailDAL.Add(model);
        }

        public void Delete(ProductDetail model)
        {
            _productDetailDAL.Delete(model);
        }

        public List<ProductDetail> GetAllIncluding()
        {
            return _productDetailDAL.GetAllIncluding().ToList();
        }

        public ProductDetail GetById(int id)
        {
            return _productDetailDAL.Get(i => i.Id == id);
        }

        public void Update(ProductDetail model)
        {
            model.UpdatedDate = DateTime.Now.ToLocalTime();
            _productDetailDAL.Update(model);
        }
    }
}
