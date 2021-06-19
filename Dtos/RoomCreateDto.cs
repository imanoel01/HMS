using HMS.Model;

namespace HMS.Dtos{


public class RoomCreateDto{
    // public int RoomNo { get; set; }
    // public string Description { get; set; }
    // public int RoomTypeId { get; set; }
    // public int Capacity { get; set; }
    // public double Rate { get; set; } 
    // public int RoomStatusId { get; set; }
        [MetaData("RoomNo", "Room Number", FieldType.text)]
        public int RoomNo { get; set; }

        [MetaData("Description", "Description", FieldType.text)]
        public string Description { get; set; }

        // [MetaData("RoomTypeId", "Room Type", FieldType.text)]
        [MetaData("RoomTypeId", "Room Type", FieldType.select,"/roomtype","Id","Name")]
        public int RoomTypeId { get; set; }

        [MetaData("Capacity", "Capacity", FieldType.text)]
        public int Capacity { get; set; }

        [MetaData("Rate", "Rate", FieldType.text)]
        public double Rate { get; set; }

        [MetaData("RoomStatusId", "Room Status", FieldType.select,"/roomstatus","Id","Name")]
        public int RoomStatusId { get; set; }
}
}