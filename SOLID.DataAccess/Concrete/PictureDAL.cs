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
    public class PictureDAL : EfEntityRepository<Picture, ApplicationDbContext>, IPictureDAL
    {
        public List<Picture> GetAllIncluding()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Set<Picture>().Include("Product").ToList();
            }
        }

        public List<Picture> GetProduct(int? id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Set<Picture>().Include("Product").Where(i => i.ProductId == id).ToList();
            }
        }
    }
}
