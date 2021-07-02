using SOLID.Core.DataAccess.EntityFramework;
using SOLID.DataAccess.Abstract;
using SOLID.DataAccess.EntityFramework;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.DataAccess.Concrete
{
    public class AboutDAL : EfEntityRepository<About, ApplicationDbContext>, IAboutDAL
    {
    }
}
