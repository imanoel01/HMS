using System.ComponentModel.DataAnnotations;

namespace HMS.EntityModel
{
    public class RoomTypeModel
    {

        [MetaData("Name", "Name", FieldType.text)]
        public string Name { get; set; }
        [MetaData("Description", "Description", FieldType.text)]
        public string Description { get; set; }
    }
}