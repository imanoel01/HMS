using System.Collections.Generic;

namespace HMS.Model{


public class Room{
    public int Id { get; set; }
    public int RoomNo { get; set; }
    public string Description { get; set; }
    
    
    public int RoomTypeId { get; set; }
    public RoomType RoomType { get; set; }
    public int Capacity { get; set; }
    public double Rate { get; set; } 
    public int Status { get; set; }
    public int RoomStatusId { get; set; }
    public RoomStatus RoomStatus { get; set; }
    // public ICollection<Bill> Bills { get; set; }
}
}