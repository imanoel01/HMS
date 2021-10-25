using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class Transactions:BaseEntity
    {
        public long BillId { get; set; }
        [ForeignKey("BillId")]
        public virtual Bill Bill { get; set; }

//TODO: for now only succesful transactions are stored in the transaction table
        // public int PaymentStatusId { get; set; }
        // public PaymentStatus PaymentStatus { get; set; }

        public  int MethodofPayment { get; set; }

    }
}