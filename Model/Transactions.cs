using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class Transactions
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public Bill Bill { get; set; }

//TODO: for now only succesful transactions are stored in the transaction table
        // public int PaymentStatusId { get; set; }
        // public PaymentStatus PaymentStatus { get; set; }

        public  int MethodofPayment { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }

    }
}