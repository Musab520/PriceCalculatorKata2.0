using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata2._0.Services
{
    public interface ICalculate
    {
        public double percentage { get; set; }
        public double amount { get; set; }
        public double priceAfter { get; set; }
        public bool applyBeforeTaxes { get; set; }
        public double calculateAmount(double price);
        public double calculatePriceAfter(double price);
    }
}
