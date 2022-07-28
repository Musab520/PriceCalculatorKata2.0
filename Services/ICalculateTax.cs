using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata2._0.Services
{
    public interface ICalculateTax
    {
        public double taxPercentage { get; set; }
        public double taxAmount { get; set; }
        public double priceAfterTax { get; set; }
        public double calculateTax(double price);
        public double calculatePriceAfterTax(double price);
    }
}
