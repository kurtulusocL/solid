using SOLID.Core.DataAccess;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.DataAccess.Abstract
{
    public interface ICommentDAL: IEntityRepository<Comment>
    {
        List<Comment> GetAllIncluding();
        List<Comment> GetProduct(int? id);
    }
}
