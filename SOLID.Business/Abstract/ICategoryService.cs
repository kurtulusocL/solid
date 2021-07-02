using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAllIncluding();
        Category GetById(int id);
        void Create(Category model);
        void Update(Category model);
        void Delete(Category model);
    }
}
