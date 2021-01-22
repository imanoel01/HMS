using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMS.Model;

namespace HMS.Data
{
    public class MockHMSRepo : IHMSRepo
    {
        public IEnumerable<Customer> getAllCustomers()
        {

            List<Customer> customers = new List<Customer>(){

new Customer{FirstName="James",LastName="Bill",MiddleName="U"},
new Customer{FirstName="Oinko",LastName="Walie", MiddleName="I"},
new Customer{FirstName="James",LastName="Bill",MiddleName="U"},
new Customer{FirstName="DOnald",LastName="Joe", MiddleName="I"},
new Customer{FirstName="Trump",LastName="Biden",MiddleName="U"},
new Customer{FirstName="JUnior",LastName="Harris", MiddleName="I"},
            };
            return customers;
        }
    }
}