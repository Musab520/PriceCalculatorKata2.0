using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PriceCalculatorKata2._0.Services
{
    public class TaxCalculator : ICalculateTax
    {
        public double taxPercentage { get; set; } = 0;
        public double taxAmount { get; set; } = 0;
        public double priceAfterTax { get; set; } = 0;
        public TaxCalculator(double percentage, double price)
        {
            taxPercentage = percentage;
            taxAmount = calculateTax(price);
            priceAfterTax = calculatePriceAfterTax(price);

        }
        public double calculateTax(double price)
        {
            double tax = (taxPercentage) * price;
            return Math.Round(tax,2);
        }

        public double calculatePriceAfterTax(double price)
        {
            return Math.Round(price + taxAmount,2);
        }
    }
}
