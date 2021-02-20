using System;

namespace HMS.Dtos
{

    public class ReadCustomerDto
    {
        // public int Id { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Occupation { get; set; }


        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}