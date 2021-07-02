using SOLID.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Entities.Concrete
{
    public class Comment : BaseHome
    {
        public string NameSurname { get; set; }
        public string EMail { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }

        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
