using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class PaymentStatus:BaseEntity
    {
      
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}