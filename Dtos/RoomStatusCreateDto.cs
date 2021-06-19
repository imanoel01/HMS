using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Dtos
{
    public class RoomStatusCreateDto
    {
        [Required]
        [MetaData("Name","Name",FieldType.text)]
        public string Name { get; set; }
              [MetaData("Description","Description", FieldType.text)]
        public string Description { get; set; }
        
        
    }
}