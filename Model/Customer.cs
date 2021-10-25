using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class Customer : BaseEntity
    {
      
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Occupation { get; set; }

      
        public string Phone { get; set; }
        
        public string Email { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }             
    }
}