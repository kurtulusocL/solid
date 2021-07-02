using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Business.Abstract
{
    public interface IAboutService
    {
        List<About> GetAll();
        About GetById(int id);
        void Create(About model);
        void Update(About model);
        void Delete(About model);
    }
}
