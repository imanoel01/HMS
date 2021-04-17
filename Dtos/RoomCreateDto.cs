using HMS.Model;

namespace HMS.Dtos{


public class RoomCreateDto{
    public int RoomNo { get; set; }
    public string Description { get; set; }
    public int RoomTypeId { get; set; }
    public int Capacity { get; set; }
    public double Rate { get; set; } 
    public int RoomStatusId { get; set; }
}
}