using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RIS4dz.Models
{
    public class StockState
    {

        public int ID { get; set; }

        [Range(0, 100000)]
        public double BuyRate { get; set; }

        [Range(0, 100000)]
        public double SellRate { get; set; }

        [Required]
        public DateTime Date { get; set; }


        public int StockID { get; set; }

        public Stock Stock { get; set; }

    }
}
