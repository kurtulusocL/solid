using SOLID.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Entities.Concrete
{
    public class Product : BaseHome
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int? Hit { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public Product()
        {
            Hit = 0;
        }
    }
}
