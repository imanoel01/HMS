using System.ComponentModel.DataAnnotations;

namespace HMS.Dtos
{

    public class CreateCustomerDto
    {


        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string Occupation { get; set; }

        [Required]
        public string Phone { get; set; }
        public string Email { get; set; }


    }
}