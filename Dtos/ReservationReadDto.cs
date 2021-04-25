using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Dtos
{
    public class ReservationReadDto
    {

       public int Id { get; set; } 
        public int CustomerId { get; set; }      
        public int RoomId { get; set; }    
        public int adult   { get; set; }
        public int children { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime ReservationDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }   
    }
}