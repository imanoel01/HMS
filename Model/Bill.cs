using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class Bill : BaseEntity
    {
        public long ReservationId { get; set; }
        [ForeignKey("ReservationId")]
        public virtual Reservation Reservation { get; set; }
        // public int RoomId { get; set; }
        // public Room Room { get; set; }
        public int NumberOfNightStay { get; set; }
        public double Discount { get; set; }
        public long PaymentStatusId { get; set; }
        [ForeignKey("PaymentStatusId")]
        public virtual PaymentStatus PaymemtStatus { get; set; }

    }
}