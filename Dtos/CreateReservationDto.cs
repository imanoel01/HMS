using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Dtos
{
    public class CreateReservationDto
    {
       
        // public int CustomerId { get; set; }
     
        // public int RoomId { get; set; }

        // public int adult   { get; set; }
        // public int children { get; set; }
        // public DateTime CheckIn { get; set; }
        // public DateTime CheckOut { get; set; }

          [MetaData("CustomerId", "Customer Id", FieldType.select, "/customer", "Id", "Phone")]
        public int CustomerId { get; set; }

        [MetaData("RoomId", "Room Id", FieldType.select, "/room", "Id", "RoomNo",true,"freerooms")]
        public int RoomId { get; set; }

        [MetaData("adult", "Adult", FieldType.number)]
        public int adult { get; set; }

        [MetaData("children", "Children", FieldType.number)]
        public int children { get; set; }

        [MetaData("CheckIn", "Check In", FieldType.date)]
        public DateTime CheckIn { get; set; }

        [MetaData("CheckOut", " Check Out", FieldType.date)]
        public DateTime CheckOut { get; set; }
       
    }
}