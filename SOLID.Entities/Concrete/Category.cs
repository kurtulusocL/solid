using SOLID.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Entities.Concrete
{
    public class Category : BaseHome
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
