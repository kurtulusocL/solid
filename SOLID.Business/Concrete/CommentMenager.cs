using SOLID.Business.Abstract;
using SOLID.DataAccess.Abstract;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOLID.Business.Concrete
{
    public class CommentMenager : ICommentService
    {
        private readonly ICommentDAL _commentDAL;
        public CommentMenager(ICommentDAL commentDAL)
        {
            _commentDAL = commentDAL;
        }
        public void Create(Comment model)
        {
            _commentDAL.Add(model);
        }

        public void Delete(Comment model)
        {
            _commentDAL.Delete(model);
        }

        public List<Comment> GetAllIncluding()
        {
            return _commentDAL.GetAllIncluding().ToList();
        }

        public Comment GetById(int id)
        {
            return _commentDAL.Get(i => i.Id == id);
        }

        public List<Comment> GetProduct(int? id)
        {
            return _commentDAL.GetProduct(id).ToList();
        }

        public void Update(Comment model)
        {
            model.UpdatedDate = DateTime.Now.ToLocalTime();
            _commentDAL.Update(model);
        }
    }
}
