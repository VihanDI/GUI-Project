using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Project.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        /*
        public Transaction(string product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        */
    }
}
