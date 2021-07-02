using SOLID.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Entities.Concrete
{
    public class Picture : BaseHome
    {
        public string ImageUrl { get; set; }

        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
