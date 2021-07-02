using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Business.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetAllIncluding();
        List<Comment> GetProduct(int? id);
        Comment GetById(int id);
        void Create(Comment model);
        void Update(Comment model);
        void Delete(Comment model);
    }
}
