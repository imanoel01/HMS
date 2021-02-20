using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Dtos
{
    public class CreateUserDto
    {
        [Required,MinLength(5)]
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        [Required,MinLength(5)]
        public string Lastname { get; set; }
        [Required,MinLength(5)]
        public string Username { get; set; }
        [Required,MinLength(5)]
        public string Email { get; set; }
        [Required,MinLength(5)]
        public string Password { get; set; }       
        
    }
}