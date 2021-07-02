using SOLID.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Entities.Concrete
{
    public class About : BaseHome
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
    }
}
