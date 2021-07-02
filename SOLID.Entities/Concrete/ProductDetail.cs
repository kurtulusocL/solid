using SOLID.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Entities.Concrete
{
    public class ProductDetail:BaseHome
    {
        public string Detail { get; set; }
        public string Subdetail { get; set; }

        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
