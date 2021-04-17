using HMS.Model;

namespace HMS.Dtos{


public class RoomReadDto{
    public int Id { get; set; }
    public int RoomNo { get; set; }
    public string Description { get; set; }
    public int RoomTypeId { get; set; }
    // public string RoomType { get; set; }
    public int Capacity { get; set; }
    public double Rate { get; set; } 
    public int RoomStatusId { get; set; }
}
}