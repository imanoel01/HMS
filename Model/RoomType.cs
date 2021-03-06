using System;
using System.Collections.Generic;

namespace HMS.Model{

   public class RoomType{
       
       public int Id { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
       public DateTime DateCreated { get; set; }
       public DateTime DateUpdated {get; set;}

       public ICollection<Room> Rooms { get; set; }
   }
}