using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class RoomStatusCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        
        
    }
}