using System.ComponentModel.DataAnnotations;

namespace HMS.Dtos
{
    public class RoomTypeCreateDto
    {

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}