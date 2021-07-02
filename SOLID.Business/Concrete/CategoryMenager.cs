using SOLID.Business.Abstract;
using SOLID.DataAccess.Abstract;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOLID.Business.Concrete
{
    public class CategoryMenager : ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;
        public CategoryMenager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }
        public void Create(Category model)
        {
            _categoryDAL.Add(model);
        }

        public void Delete(Category model)
        {
            _categoryDAL.Delete(model);
        }

        public List<Category> GetAllIncluding()
        {
            return _categoryDAL.GetAllIncluding().ToList();
        }

        public Category GetById(int id)
        {
            return _categoryDAL.Get(i => i.Id == id);
        }

        public void Update(Category model)
        {
            model.UpdatedDate = DateTime.Now.ToLocalTime();
            _categoryDAL.Update(model);
        }
    }
}
