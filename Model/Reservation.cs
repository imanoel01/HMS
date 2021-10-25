using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using HMS.Model;

namespace HMS.Model
{
    public class Reservation : BaseEntity
    {
        
        public long CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public long RoomId { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }

        public int adult   { get; set; }
        public int children { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime ReservationDate { get; set; }
   


    }
}