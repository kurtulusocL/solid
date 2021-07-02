using Microsoft.EntityFrameworkCore;
using SOLID.Core.DataAccess.EntityFramework;
using SOLID.DataAccess.Abstract;
using SOLID.DataAccess.EntityFramework;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOLID.DataAccess.Concrete
{
    public class ProductDAL : EfEntityRepository<Product, ApplicationDbContext>, IProductDAL
    {
        public List<Product> Category(int? id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Set<Product>().Include("Category").Include("Comments").Include("Pictures").Include("ProductDetails").Where(i => i.CategoryId == id).ToList();
            }
        }

        public List<Product> GetAllIncluding()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Set<Product>().Include("Category").Include("Comments").Include("Pictures").Include("ProductDetails").ToList();
            }
        }

        public ProductDetail GetProductDetail(int? id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Set<ProductDetail>().Where(i => i.ProductId == id).FirstOrDefault();
            }
        }

        public Product HitRead(int? id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var hit = context.Set<Product>().Where(i => i.Id == id).SingleOrDefault();
                hit.Hit++;
                context.SaveChanges();
                return hit;
            }
        }
    }
}
