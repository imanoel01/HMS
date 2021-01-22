using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMS.Model;

namespace HMS.Data
{
    public interface IHMSRepo
    {
        IEnumerable<Customer> getAllCustomers();
    }
}