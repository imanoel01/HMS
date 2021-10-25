using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Model
{


    public class Room : BaseEntity
    {

        public string RoomName { get; set; }
        public string Description { get; set; }
        public long RoomTypeId { get; set; }
        [ForeignKey("RoomTypeId")]
        public virtual RoomType RoomType { get; set; }
        public int Capacity { get; set; }
         [Column(TypeName = "decimal(18,2)")]
        public decimal Rate { get; set; }
        public int Status { get; set; }
        public long RoomStatusId { get; set; }
        [ForeignKey("RoomStatusId")]
        public virtual RoomStatus RoomStatus { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}