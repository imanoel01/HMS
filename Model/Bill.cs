using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class Bill
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        // public int RoomId { get; set; }
        // public Room Room { get; set; }
        public int NumberOfNightStay { get; set; }
        public double Discount { get; set; }
        public int PaymentStatusId { get; set; }
       public PaymentStatus PaymemtStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime  DateCreated { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}