using SOLID.Business.Abstract;
using SOLID.DataAccess.Abstract;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOLID.Business.Concrete
{
    public class AboutMenager : IAboutService
    {
        IAboutDAL _aboutDAL;
        public AboutMenager(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;
        }
        public void Create(About model)
        {
            _aboutDAL.Add(model);
        }

        public void Delete(About model)
        {
            _aboutDAL.Delete(model);
        }

        public List<About> GetAll()
        {
            return _aboutDAL.GetAll().ToList();
        }

        public About GetById(int id)
        {
            return _aboutDAL.Get(i => i.Id == id);
        }

        public void Update(About model)
        {
            model.UpdatedDate = DateTime.Now.ToLocalTime();
            _aboutDAL.Update(model);
        }
    }
}
