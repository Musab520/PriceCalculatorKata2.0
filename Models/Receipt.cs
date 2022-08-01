using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata2._0.Models
{
    public class Receipt
    {
        public Receipt()
        {

        }
        public Product product { get; set; }
        public double tax { get; set; } = 0;
        public double taxPercentage { get; set; } = 0;
        public double priceAfter { get; set; } = 0;

    }
}
