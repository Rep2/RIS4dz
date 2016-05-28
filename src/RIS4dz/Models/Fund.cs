using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RIS4dz.Models
{
    public class Fund
    {

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<StockMultiplyer> Stocks { get; set; }


        public double TotalValue()
        {
            var totalMultiplyer = Stocks.Sum(s => s.Multiplyer);

            double totalValue = 0;

            foreach(StockMultiplyer multiplyer in Stocks)
            {
                var states = multiplyer.Stock.States;

                if (states != null)
                {
                    var state = states.OrderByDescending(s => s.Date).FirstOrDefault();

                    if (state != null)
                    {
                        totalValue += state.SellRate * multiplyer.Multiplyer / totalMultiplyer;
                    }
                }
            }

            return totalValue;
        }

    }

    public class StockMultiplyer
    {

        public int ID { get; set; }

        public double Multiplyer { get; set; }


        public int StockID { get; set; }

        public Stock Stock { get; set; }


        public int FundID { get; set; }

        public Fund Fund { get; set; }


        
    }
}
