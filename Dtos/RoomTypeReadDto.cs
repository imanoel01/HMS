using System;

namespace HMS.Dtos{
    public class RoomTypeReadDto{
        public int Id { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
       public DateTime DateCreated { get; set; }
       public DateTime DateUpdated {get; set;}
    }
}