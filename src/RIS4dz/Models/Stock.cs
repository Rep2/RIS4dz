using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RIS4dz.Models
{
    public class Stock
    {

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public List<StockState> States { get; set; }

    }
}
