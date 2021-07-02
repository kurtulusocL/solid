using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SOLID.Core.Entities
{
    public class BaseHome:IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public BaseHome()
        {
            CreatedDate = DateTime.Now.ToLocalTime();
        }
    }
}
