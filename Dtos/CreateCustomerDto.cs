using System.ComponentModel.DataAnnotations;

namespace HMS.Dtos
{

    public class CreateCustomerDto
    {


        // [Required]
        // public string FirstName { get; set; }

        // public string MiddleName { get; set; }
        // [Required]
        // public string LastName { get; set; }

        // public string Occupation { get; set; }

        // [Required]
        // public string Phone { get; set; }
        // public string Email { get; set; }


        [MetaData("FirstName", "First Name", FieldType.text)]
        public string FirstName { get; set; }
        [MetaData("MiddleName", "Middle Name", FieldType.text)]
        public string MiddleName { get; set; }
        
        [MetaData("LastName", "Last Name", FieldType.text)]
        public string LastName { get; set; }
        [MetaData("Occupation", "Occupation", FieldType.text)]
        public string Occupation { get; set; }

        [MetaData("Phone", "Phone", FieldType.tel)]
        public string Phone { get; set; }
        [MetaData("Email", "Email", FieldType.email)]
        public string Email { get; set; }



    }
}