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
    public class CategoryDAL : EfEntityRepository<Category, ApplicationDbContext>, ICategoryDAL
    {
        public List<Category> GetAllIncluding()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Set<Category>().Include("Products").ToList();
            }
        }
    }
}
