using SOLID.Business.Abstract;
using SOLID.DataAccess.Abstract;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOLID.Business.Concrete
{
    public class ProductMenager : IProductService
    {
        private readonly IProductDAL _productDAL;
        public ProductMenager(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public List<Product> Category(int? id)
        {
            return _productDAL.Category(id);
        }

        public void Create(Product model)
        {
            _productDAL.Add(model);
        }

        public void Delete(Product model)
        {
            _productDAL.Delete(model);
        }

        public List<Product> GetAllIncluding()
        {
            return _productDAL.GetAllIncluding().ToList();
        }

        public Product GetById(int id)
        {
            return _productDAL.Get(i => i.Id == id);
        }

        public ProductDetail GetProductDetail(int? id)
        {
            return _productDAL.GetProductDetail(id);
        }

        public Product HitRead(int? id)
        {
            return _productDAL.HitRead(id);
        }

        public void Update(Product model)
        {
            model.UpdatedDate = DateTime.Now.ToLocalTime();
            _productDAL.Update(model);
        }
    }
}
