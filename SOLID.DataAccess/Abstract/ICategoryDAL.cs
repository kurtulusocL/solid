using SOLID.Core.DataAccess;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.DataAccess.Abstract
{
    public interface ICategoryDAL : IEntityRepository<Category>
    {
        List<Category> GetAllIncluding();
    }
}
