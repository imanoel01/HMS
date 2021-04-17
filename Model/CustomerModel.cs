using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class CustomerModel
    {
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

        // [MetaData("RoomType", "Room Type", FieldType.select,"/roomtype","Name","Name")]
        // public string RoomType { get; set; }

    }
}