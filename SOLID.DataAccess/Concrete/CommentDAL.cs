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
    public class CommentDAL : EfEntityRepository<Comment, ApplicationDbContext>, ICommentDAL
    {
        public List<Comment> GetAllIncluding()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Set<Comment>().Include("Product").ToList();
            }
        }

        public List<Comment> GetProduct(int? id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Set<Comment>().Include("Product").Where(i => i.ProductId == id).ToList();
            }
        }
    }
}
