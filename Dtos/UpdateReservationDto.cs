using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Dtos
{
    public class UpdateReservationDto
    {
        public int Id { get; set; } 
        public int CustomerId { get; set; }
        public int adult   { get; set; }
        public int children { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}