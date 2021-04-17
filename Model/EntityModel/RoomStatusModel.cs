using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.EntityModel
{
    public class RoomStatusModel
    {
        [MetaData("Name","Name",FieldType.text)]
        public string Name { get; set; }
        [MetaData("Description","Description", FieldType.text)]
        public string Description { get; set; }
        
        
    }
}