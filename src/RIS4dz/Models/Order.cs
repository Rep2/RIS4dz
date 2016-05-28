using RIS4dz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RIS4dz.Models
{
    public class Order
    {
        public int ID { get; set; }

        public int NumberOfShares { get; set; }

        public DateTime DateOrdered { get; set; }

        public double ShareValueAtOrder { get; set; }

        public double TotalValueAtOrder { get; set; }

        public double TransactionFee { get; set; }

    }

    public class StockOrder : Order
    {
        public int StockID { get; set; }

        public Stock Stock { get; set; }
    }

    public class FundOrder : Order
    {
        public int FundID { get; set; }

        public Fund Fund { get; set; }
    }
}
