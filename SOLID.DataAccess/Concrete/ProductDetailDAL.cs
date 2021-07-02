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
    public class ProductDetailDAL : EfEntityRepository<ProductDetail, ApplicationDbContext>, IProductDetailDAL
    {
        public List<ProductDetail> GetAllIncluding()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Set<ProductDetail>().Include("Product").ToList();
            }
        }
    }
}
